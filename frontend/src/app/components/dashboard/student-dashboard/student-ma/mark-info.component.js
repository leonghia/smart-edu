import { data } from "../../../../app.store";
import studentMaService from "./student-ma.service";
import { calculateGPA, calculateGPASummary, calculateRankingSemester1, determineQualify, getAcademicYears, lastNameFromFullName } from "../../../../helpers/util.helper";
import { getMarksFromAcademicYearAndSemester } from "../../../../helpers/util.helper";
import { getMainClassFromSemester } from "../../../../helpers/filter.helper";
import dataService from "../../../../services/data.service";
import { MarkFilterOption } from "../../../../models/markFilterOption";
import { mark } from "regenerator-runtime";

export class MarkInfoComponent extends HTMLElement {

    #student;
    #user;
    #semesterName;
    #mainClass;
    #academicYears;
    #marks;
    #gpa;
    #qualify;
    #headTeacher;
    #rankingText;

    constructor() {
        super();
        studentMaService.subscribe("switchSemester", {
            component: this,
            eventHandler: this.#handleSwitchTable
        });
        studentMaService.subscribe("switchSummary", {
            component: this,
            eventHandler: this.#handleSwitchSummary
        })
        this.#user = data.currentUser;
        this.#student = data.currentUser.student;


    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#semesterName = this.querySelector(".semester-name");
        this.#mainClass = this.querySelector(".main-class");
        this.#gpa = this.querySelector(".gpa");
        this.#qualify = this.querySelector(".qualify");
        this.#headTeacher = this.querySelector(".head-teacher");
        this.#rankingText = this.querySelector(".ranking-text");

        this.#academicYears = getAcademicYears(data.currentUser.student.marks);
        const marks = getMarksFromAcademicYearAndSemester(data.currentUser.student.marks, {
            fromYear: this.#academicYears[0].fromYear,
            toYear: this.#academicYears[0].toYear,
            semester: 1
        });
        this.#handleSwitchTable(marks);

        dataService.getMainClassById(this.#student.mainClass.id)
            .then(res => {
                this.#headTeacher.textContent = res.data.teacher.user.fullName;
            });
    }

    disconnectedCallback() {
        studentMaService.unSubscribe("switchSemester", this);
    }

    #handleSwitchTable(marks) {
        this.#marks = marks;
        const semester = marks[0].semester;
        const fromYear = marks[0].fromYear;
        const toYear = marks[0].toYear;
        this.#semesterName.textContent = `Semester ${semester} (${fromYear} - ${toYear})`;
        this.#mainClass.textContent = `${getMainClassFromSemester(this.#academicYears, marks)}${this.#student.mainClass.name.slice(-1)}`;
        const gpa = calculateGPA(marks);
        this.#gpa.textContent = gpa || "-";
        const mainClassId = data.currentUser.student.mainClass.id;
        this.#qualify.textContent = determineQualify(gpa) || "-";

        const markFilterOption = new MarkFilterOption(semester, fromYear, toYear);
        if (gpa) {
            dataService.getRanking(data.currentUser.student.id, markFilterOption)
                .then(res => {
                    this.#rankingText.firstElementChild.textContent = `${res.data.ranking}/${res.data.numbersOfStudents}`;
                });
        } else {
            this.#rankingText.firstElementChild.textContent = "-";
        }
    }

    #handleSwitchSummary(marksSemester1) {
        const fromYear = marksSemester1[0].fromYear;
        const toYear = marksSemester1[0].toYear;
        this.#semesterName.textContent = `Summary (${fromYear} - ${toYear})`;
        this.#mainClass.textContent = `${getMainClassFromSemester(this.#academicYears, marksSemester1)}${this.#student.mainClass.name.slice(-1)}`;
        const gpa = calculateGPASummary(data.currentUser.student.marks, marksSemester1);
        this.#gpa.textContent = gpa || "-";
        this.#qualify.textContent = determineQualify(gpa) || "-";

        const markFilterOption = new MarkFilterOption(3, fromYear, toYear);
        if (gpa) {
            dataService.getRanking(data.currentUser.student.id, markFilterOption)
                .then(res => {
                    this.#rankingText.firstElementChild.textContent = `${res.data.ranking}/${res.data.numbersOfStudents}`;
                });
        } else {
            this.#rankingText.firstElementChild.textContent = "-";
        }
    }

    #render() {
        return `
    <div class="bg-gray-800 mb-8 rounded-xl">
        <div class="mx-auto max-w-7xl">
            <div class="grid grid-cols-1 gap-px bg-white/5 sm:grid-cols-3 lg:grid-cols-3">
                <div class="bg-gray-800 px-4 py-6 sm:px-6 lg:px-8 rounded-l-xl">
                    <p class="text-sm font-medium leading-6 text-gray-400">GPA</p>
                    <p class="mt-2 flex items-baseline gap-x-2">
                        <span class="text-2xl font-semibold tracking-tight text-white gpa"></span>
                    </p>
                </div>
                <div class="bg-gray-800 px-4 py-6 sm:px-6 lg:px-8">
                    <p class="text-sm font-medium leading-6 text-gray-400">Ranking</p>
                    <p class="ranking-text mt-2 flex items-baseline gap-x-2">
                        <span class="text-2xl font-semibold tracking-tight text-white"></span>
                    </p>
                </div>
                <div class="bg-gray-800 px-4 py-6 sm:px-6 lg:px-8 rounded-r-xl">
                    <p class="text-sm font-medium leading-6 text-gray-400">Qualify</p>
                    <p class="mt-2 flex items-baseline gap-x-2">
                        <span class="text-2xl font-semibold tracking-tight text-white qualify"></span>
                    </p>
                </div>
            </div>
        </div>
    </div>  
    <div class="overflow-hidden bg-amber-50 sm:rounded-xl">
        <div class="px-4 py-6 sm:px-6">
            <h3 class="text-base font-semibold leading-7 text-orange-600">Marks Information</h3>
            <p class="mt-1 max-w-2xl text-sm leading-6 text-gray-500">Semester details and statistics.</p>
        </div>
        <div class="border-t border-dashed border-gray-400">
            <dl class="divide-y divide-dashed divide-gray-400">
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6 items-center">
                    <dt class="text-sm font-medium text-gray-900">Period</dt>
                    <dd class="semester-name mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0"></dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6 items-center">
                    <dt class="text-sm font-medium text-gray-900">Student name</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">${this.#user.fullName}</dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6 items-center">
                    <dt class="text-sm font-medium text-gray-900">Main class</dt>
                    <dd class="main-class mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">-</dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6 items-center">
                    <dt class="text-sm font-medium text-gray-900">Head teacher</dt>
                    <dd class="head-teacher mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0"></dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                    <dt class="text-sm font-medium text-gray-900">Teacher feedback</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">${lastNameFromFullName(this.#user.fullName)} shows incredible motivation and always tries to put his best effort into assignments. His continued commitment leads me to believe he going to experience great academic success.</dd>
                </div>             
            </dl>
        </div>
    </div>        
        `;
    }
}

customElements.define("mark-info", MarkInfoComponent);
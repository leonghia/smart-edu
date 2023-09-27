import { data } from "../../app.store";
import { getAcademicYears, getMarksFromAcademicYearAndSemester } from "../../helpers/util.helper";
import studentMaService from "../dashboard/student-dashboard/student-ma/student-ma.service";

export class MarkTableComponent extends HTMLElement {

    #tableBody;

    constructor() {
        super();
        studentMaService.subscribe("switchTable", {
            component: this,
            eventHandler: this.#displayRows
        });
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#tableBody = this.querySelector("tbody");
        const academicYears = getAcademicYears(data.currentUser.student.marks);
        const marks = getMarksFromAcademicYearAndSemester(data.currentUser.student.marks, {
            fromYear: academicYears[0].fromYear,
            toYear: academicYears[0].toYear,
            semester: 1
        });
        this.#displayRows(marks);
    }

    disconnectedCallback() {
        studentMaService.unSubscribe("switchTable", this);
    }

    #render() {
        return `
    <div class="relative overflow-x-auto rounded-xl bg-gray-200">
        <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-white uppercase bg-fuchsia-500 dark:bg-fuchsia-600">
                <tr>
                    <th scope="col" class="px-6 py-3 border-r border-dashed border-gray-400">
                        Subject name
                    </th>
                    <th scope="col" colspan="2" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        Oral test
                    </th>
                    <th scope="col" colspan="3" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        15-minute test
                    </th>
                    <th scope="col" colspan="2" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        45-minute-test
                    </th>
                    <th scope="col" colspan="1" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        Semester test
                    </th>
                    <th scope="col" colspan="1" class="text-center px-6 py-3">
                        Average
                    </th>
                </tr>
            </thead>
            <tbody>
                           
            </tbody>
        </table>
    </div>          
        `;
    }

    #renderRow(mark) {
        return `
    <tr class="bg-white bg-opacity-70 border-b border-dashed border-gray-400 dark:bg-gray-800 dark:border-gray-700">
        <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.subject.name}
        </th>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.oral_1 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.oral_2 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.test15_1 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.test15_2 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.test15_3 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.test45_1 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.test45_2 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            ${mark.test60 || "N/A"}
        </td>
        <td class="text-center px-6 py-4 font-medium text-gray-800">
            N/A
        </td>
    </tr>  
        `;
    } 

    #displayRows(marks) {
        this.#tableBody.innerHTML = "";
        marks.forEach(mark => this.#tableBody.insertAdjacentHTML("beforeend", this.#renderRow(mark)));
        if (this.#tableBody.lastElementChild) {
            this.#tableBody.lastElementChild.classList.remove(..."border-b border-dashed border-gray-400".split(" "));
        }
    }
}

customElements.define("mark-table", MarkTableComponent);
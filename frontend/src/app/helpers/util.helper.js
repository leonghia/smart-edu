import { Mark } from "../models/mark";
import { SUBJECT_STYLING } from "../app.enum";

export const checkDuplicatedSchedule = function (extraClass) {

}

export const isExtraClassRegistered = function (extraClass, registeredExtraClasses) {
    return registeredExtraClasses.some(ec => ec.id === extraClass.id);
}

export const isExtraClassFull = function (extraClass) {
    return extraClass.capacity === extraClass.students.length;
}

export const checkIfEcIsBookmarked = function (extraClass, ecBookmark) {
    return ecBookmark.extraClasses.some(ec => ec.id === extraClass.id);
}

export const lastNameFromFullName = function (fullName) {
    const fullNameArr = fullName.split(" ");
    return fullNameArr[fullNameArr.length - 1];
}

export const getAcademicYears = function(marks) {
    const subjectId = marks[0].subject.id;
    const marksOfSameSubject = marks.filter(m => m.subject.id === subjectId && m.semester === 1);
    return marksOfSameSubject.map(m => ({
        fromYear: m.fromYear,
        toYear: m.toYear
    }));
}

export const getMarksFromAcademicYearAndSemester = function(marks = [], option = {fromYear: 0, toYear: 0, semester: 0}) {
    return marks.filter(m => m.fromYear === option.fromYear && m.toYear === option.toYear && m.semester === option.semester);
}

export const displayRating = function(rating) {
    const temp = `
    <svg class="text-gray-300 h-5 w-5 flex-shrink-0" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
        <path fill-rule="evenodd"
        d="M10.868 2.884c-.321-.772-1.415-.772-1.736 0l-1.83 4.401-4.753.381c-.833.067-1.171 1.107-.536 1.651l3.62 3.102-1.106 4.637c-.194.813.691 1.456 1.405 1.02L10 15.591l4.069 2.485c.713.436 1.598-.207 1.404-1.02l-1.106-4.637 3.62-3.102c.635-.544.297-1.584-.536-1.65l-4.752-.382-1.831-4.401z"
        clip-rule="evenodd" />
    </svg>
    <svg class="text-gray-300 h-5 w-5 flex-shrink-0" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
        <path fill-rule="evenodd"
        d="M10.868 2.884c-.321-.772-1.415-.772-1.736 0l-1.83 4.401-4.753.381c-.833.067-1.171 1.107-.536 1.651l3.62 3.102-1.106 4.637c-.194.813.691 1.456 1.405 1.02L10 15.591l4.069 2.485c.713.436 1.598-.207 1.404-1.02l-1.106-4.637 3.62-3.102c.635-.544.297-1.584-.536-1.65l-4.752-.382-1.831-4.401z"
        clip-rule="evenodd" />
    </svg>
    <svg class="text-gray-300 h-5 w-5 flex-shrink-0" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
        <path fill-rule="evenodd"
        d="M10.868 2.884c-.321-.772-1.415-.772-1.736 0l-1.83 4.401-4.753.381c-.833.067-1.171 1.107-.536 1.651l3.62 3.102-1.106 4.637c-.194.813.691 1.456 1.405 1.02L10 15.591l4.069 2.485c.713.436 1.598-.207 1.404-1.02l-1.106-4.637 3.62-3.102c.635-.544.297-1.584-.536-1.65l-4.752-.382-1.831-4.401z"
        clip-rule="evenodd" />
    </svg>
    <svg class="text-gray-300 h-5 w-5 flex-shrink-0" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
        <path fill-rule="evenodd"
        d="M10.868 2.884c-.321-.772-1.415-.772-1.736 0l-1.83 4.401-4.753.381c-.833.067-1.171 1.107-.536 1.651l3.62 3.102-1.106 4.637c-.194.813.691 1.456 1.405 1.02L10 15.591l4.069 2.485c.713.436 1.598-.207 1.404-1.02l-1.106-4.637 3.62-3.102c.635-.544.297-1.584-.536-1.65l-4.752-.382-1.831-4.401z"
        clip-rule="evenodd" />
    </svg>
    <svg class="text-gray-300 h-5 w-5 flex-shrink-0" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
        <path fill-rule="evenodd"
        d="M10.868 2.884c-.321-.772-1.415-.772-1.736 0l-1.83 4.401-4.753.381c-.833.067-1.171 1.107-.536 1.651l3.62 3.102-1.106 4.637c-.194.813.691 1.456 1.405 1.02L10 15.591l4.069 2.485c.713.436 1.598-.207 1.404-1.02l-1.106-4.637 3.62-3.102c.635-.544.297-1.584-.536-1.65l-4.752-.382-1.831-4.401z"
        clip-rule="evenodd" />
    </svg>
    `;
    if(rating < 0.5) return temp;
    if(rating >= 0.5 && rating <= 1.4) {
        return temp.replace("text-gray-300", "text-yellow-400");
    };
    if(rating >= 1.5 && rating <= 2.4) {
        return temp.replace("text-gray-300", "text-yellow-400").replace("text-gray-300", "text-yellow-400");
    }
    if(rating >=2.5 && rating <= 3.4) {
        return temp.replace("text-gray-300", "text-yellow-400").replace("text-gray-300", "text-yellow-400").replace("text-gray-300", "text-yellow-400");
    }
    if(rating >=3.5 && rating <= 4.4) {
        return temp.replace("text-gray-300", "text-yellow-400").replace("text-gray-300", "text-yellow-400").replace("text-gray-300", "text-yellow-400").replace("text-gray-300", "text-yellow-400");
    }
    if(rating >= 4.5) {
        return temp.replaceAll("text-gray-300", "text-yellow-400");
    }
}

export const calculateAverageMark = function(mark = new Mark()) {
    const values = Object.values(mark);
    if (values.some(v => !v)) {
        return undefined;
    }
    const temp = ((mark.oral_1 + mark.oral_2 + mark.test15_1 + mark.test15_2 + mark.test15_3) + (mark.test45_1 + mark.test45_2) * 2 + mark.test60 * 3) / 12;
    return Number(temp.toFixed(2));
}

export const calculateAverageMarkSummary = function(markSemester1, markSemester2) {
    if (!markSemester1 || !markSemester2) return undefined;
    const result = Number(((markSemester1 + markSemester2 * 2) / 3).toFixed(2));
    return result;
}

export const calculateGPA = function(marks = []) {
    let sum = 0;
    for (const m of marks) {
        if (!calculateAverageMark(m)) {
            return undefined;
        }
        sum += calculateAverageMark(m);
    }
    return Number((sum / marks.length).toFixed(2));
}

export const calculateGPASummary = function(marks, marksSemester1 = []) {
    let sum = 0;
    for (const m of marksSemester1) {
        const markSemester2 = getMarkSemester2(marks, m);
        if (!calculateAverageMarkSummary(calculateAverageMark(m), calculateAverageMark(markSemester2))) {
            return undefined;
        }  
        sum += calculateAverageMarkSummary(calculateAverageMark(m), calculateAverageMark(markSemester2));
    }
    return Number((sum / marksSemester1.length).toFixed(2));
}

export const determineQualify = function(gpa = 0) {
    if (!gpa) return undefined;
    if (gpa >= 9.0) return "Excellent";
    if (gpa >= 8.0) return "Good";
    if (gpa >= 6.5) return "OK";
    if (gpa >= 5.0) return "Average";
    return "Weak";
}

export const getMarkSemester2 = function(marks = [], markSemester1 = new Mark()) {
    return marks.find(m => m.subject.id === markSemester1.subject.id && m.fromYear === markSemester1.fromYear && m.toYear === markSemester1.toYear && m.semester === 2);
}
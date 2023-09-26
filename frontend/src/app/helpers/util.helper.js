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
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


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
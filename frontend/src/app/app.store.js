export const state = {
    darkMode: false,
};

export const data = {
    students: [],
    parents: [],
    extraClasses: [],
    currentUser : {
        
    }
}

export const getStudents = function () {
    return data.students;
}

export const saveStudents = function(students) {
    data.students = students;
}

export const getExtraClasses = function() {
    return data.extraClasses;
}

export const saveExtraClasses = function (extraClasses) {
    data.extraClasses = extraClasses;
}
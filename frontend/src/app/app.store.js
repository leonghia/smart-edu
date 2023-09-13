export const state = {
    darkMode: false
};

const data = {
    students: [],
    parents: []
}

export const getStudents = function () {
    return data.students;
}

export const saveStudents = function(students) {
    data.students = students;
}
const state = {
    students: [],
    parents: [],

};

export const getStudents = function () {
    return state.students;
}

export const saveStudents = function(students) {
    state.students = students;
}
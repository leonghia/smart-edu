import { async } from "regenerator-runtime";
import dataService from "./services/data.service.js";

const state = {
    students: [],
    parents: [],

};

export const getStudents = function () {
    return state.students;
}

export const refreshStudents = async function () {
    state.students = await dataService.getStudents();
}
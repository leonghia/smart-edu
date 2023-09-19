import { data } from "../app.store"

export const checkDuplicatedSchedule = function(extraClass) {
    
}

export const isExtraClassRegistered = function(extraClass, registeredExtraClasses) {
    return registeredExtraClasses.some(ec => ec.id === extraClass.id);
}

export const isExtraClassFull = function(extraClass) {
    return extraClass.capacity === extraClass.students.length;
}
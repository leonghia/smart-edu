import { data } from "../app.store";

export const checkDuplicatedSchedule = function(extraClass) {
    
}

export const isExtraClassRegistered = function(extraClass, registeredExtraClasses) {
    return registeredExtraClasses.some(ec => ec.id === extraClass.id);
}

export const isExtraClassFull = function(extraClass) {
    return extraClass.capacity === extraClass.students.length;
}

export const lastNameFromFullName = function(fullName ){
    // "Trinh Van Phuc" => ["Trinh", "Van", "Phuc"] => "Phuc"
    // split(" ")
    const fullNameArr = fullName = fullName.split(" "); // ["Trinh", "Van", "Phuc"]
    return fullNameArr[fullNameArr.length - 1];
}
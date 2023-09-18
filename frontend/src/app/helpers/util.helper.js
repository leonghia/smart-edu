export const lastNameFromFullName = function(fullName){
    // "Trinh Van Phuc" => ["Trinh", "Van", "Phuc"] => "Phuc"
    // split(" ")
    const fullNameArr = fullName = fullName.split(" "); // ["Trinh", "Van", "Phuc"]
    return fullNameArr[fullNameArr.length - 1];
}
import dataService from "../services/data.service";
// Hàm lọc học sinh theo Id lơp học
export const filterStudentByMainClass = function(students, mainClassId){
    // cach 1
    // return students.filter(s => s.mainClass.id === mainClassId);

    // cach 2: dung vong lap
    // 2.1: vong lap for let i 

    const results = [];
    for(let i = 0; i < students.length; i++){
        if(students[i].mainClass.id === mainClassId){
            results.push(students[i])
        }
    }
    return results;

    //2.2: vong lap for of
    // const results = [];
    // for (const student of students){
    //     if(student.mainClass.id === mainClassId){
    //         results.push(student);
    //     }
    // }
    // return results;

}

export const renderMainClassesDropdownItem = function (mainClass) {
    return `
    <li class="flex items-center">
        <input id="${mainClass.id}" type="radio" value="${mainClass.name}" name="main-classes"
        class="w-4 h-4 bg-gray-100 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500 dark:focus:ring-fuchsia-600 dark:ring-offset-gray-700 dark:bg-gray-600 dark:border-gray-500" />
        <label for="apple" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-100">
        ${mainClass.name} (${getTotalStudents(mainClass.id)})
        </label>
    </li> 
    `;
}

export const getTotalStudents = function (mainClassId) {
    return getStudents().filter(s => s.mainClass.id === mainClassId).length;
}

export const displayMainClassFilterDropdown = function (dropdownContainer) {
    dataService.getMainClasses()
        .then(data => {
            const mainClasses = data.data;
            mainClasses.forEach(mC => {
                dropdownContainer.insertAdjacentHTML("beforeend", renderMainClassesDropdownItem(mC));
            });
        });
}
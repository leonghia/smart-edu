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
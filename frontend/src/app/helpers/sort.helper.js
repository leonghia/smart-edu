export const sortByName = function(students){

    // Buoc1: Dao nguoc lai ten cho tung hoc sinh
    const reversed = students.map(s => s.user.fullName.split(" ").reverse().join(" "));
    
    // Buoc 2: Tien hanh sap xep
    students.forEach(currenentValue => {
        // Tao ban sao cua tung hoc sinh de sap xep, khon lam anh huong den du lieu trong DB
        const student = Object.assign({},currenentValue);
    });

    return students.sort(function(a,b){
        const a_revered = a.user.fullName.split(" ").reverse().join(" ");
        const b_revered = b.user.fullName.split(" ").reverse().join(" ");
        console.log(a_revered,b_revered);
        return a_revered.localeCompare(b_revered);
    });
}
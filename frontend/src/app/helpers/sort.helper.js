export const sortByName = function (students) {

    return students.sort(function(a,b){
        const a_revered = a.user.fullName.split(" ").reverse().join(" ");
        const b_revered = b.user.fullName.split(" ").reverse().join(" ");
        return a_revered.localeCompare(b_revered);
    });
}

export const sortByMainClass = function(students) {
    return students.sort((a, b) => a.mainClass.id - b.mainClass.id);
}
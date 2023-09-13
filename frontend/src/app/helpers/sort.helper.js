export const sortByName = function (students, asc = true) {

    return students.sort(function (a, b) {
        const a_reversed = a.user.fullName.split(" ").reverse().join(" ");
        const b_reversed = b.user.fullName.split(" ").reverse().join(" ");
        if (asc) {
            return a_reversed.localeCompare(b_reversed);
        } else {
            return b_reversed.localeCompare(a_reversed);
        }

    });
}

export const sortByDob = function (students, asc = true) {
    return students.sort(function (a, b) {
        const a_date = Date.parse(a.user.dateOfBirth);
        const b_date = Date.parse(b.user.dateOfBirth);
        if (asc) {
            return a_date - b_date;
        } else {
            return b_date - a_date;
        }
    })
}

export const sortByMainClass = function (students) {
    return students.sort((a, b) => a.mainClass.id - b.mainClass.id);
}
export const searchByName = function (arr, name, isHuman = 1) {
    //Buoc 1: Tao mang chua ket qua
    let results = [];
    //Buoc 2: Duyet vong lap qua mang loc ra nhung phan tu co ten chua name va de no vao trong mang ket qua
    results = arr.filter(currentValue => currentValue.user.fullName.toLowerCase().includes(name.toLowerCase()));
    //arr = ["Huong", "Phuc", "Quoc", "Nghia"]
    //name = "u" 
    return results;
}

export const searchByIdentifier = function (arr, identifier) {
    return arr.filter(e => e.user.identifier.toLowerCase().includes(identifier.toLowerCase()));
}

export const searchByEmail = function (arr, email) {
    return arr.filter(e => e.user.email.toLowerCase().includes(email.toLowerCase()));
}
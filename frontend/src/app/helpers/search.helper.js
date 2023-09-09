export const searchByName = function(arr, name) {
    //Buoc 1: Tao mang chua ket qua
    let results = [];
    //Buoc 2: Duyet vong lap qua mang loc ra nhung phan tu co ten chua name va de no vao trong mang ket qua
    results = arr.filter(currentValue => currentValue.fullName.toLowerCase().includes(name.toLowerCase()));
    //arr = ["Huong", "Phuc", "Quoc", "Nghia"]
    //name = "u" 
    return results;
}
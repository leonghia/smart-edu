export const searchByName = function (arr, name, isHuman = true) {
    if (!name) {
        return arr;
    }
    return arr.filter(currentValue => currentValue.user.fullName.toLowerCase().includes(name.toLowerCase()));
}

export const searchByIdentifier = function (arr, identifier) {
    if (!identifier) {
        return arr;
    }
    return arr.filter(e => e.user.identifier.toLowerCase().includes(identifier.toLowerCase()));
}

export const searchByEmail = function (arr, email) {
    if (!email) {
        return arr;
    }
    return arr.filter(e => e.user.email.toLowerCase().includes(email.toLowerCase()));
}
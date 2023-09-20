export const showDropdown = function (dropdown, items = [], state = {}) {
    dropdown.classList.remove("pointer-events-none");
    dropdown.classList.remove("ease-in", "duration-300");
    dropdown.classList.add("ease-out", "duration-500");
    dropdown.classList.remove("transform", "opacity-0" , "scale-95");
    dropdown.classList.add("transform", "opacity-100", "scale-100");  
    state.state = true;
    items.forEach(mI => mI.classList.add("cursor-pointer"));
}

export const hideDropdown = function (dropdown, items = [], state = {}) {
    dropdown.classList.remove("ease-out", "duration-500");
    dropdown.classList.add("ease-in", "duration-300");
    dropdown.classList.remove("transform", "opacity-100", "scale-100");
    dropdown.classList.add("transform", "opacity-0" , "scale-95");          
    state.state = false;
    items.forEach(mI => mI.classList.remove("cursor-pointer"));
    dropdown.classList.add("pointer-events-none");
}
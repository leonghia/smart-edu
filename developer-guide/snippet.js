// Search bar dropdown
dropdownBtn.addEventListener("click", function() {
    if (this.#dropdownOptionsState) {    
		dropdownOptions.classList.remove("ease-out", "duration-1000");
        dropdownOptions.classList.add("ease-in", "duration-300");
        dropdownOptions.classList.remove("transform", "opacity-100", "scale-100");
        dropdownOptions.classList.add("transform", "opacity-0" , "scale-95");
        this.#dropdownOptionsState= false;
    } else {
        dropdownOptions.classList.remove("ease-in", "duration-300");
        dropdownOptions.classList.add("ease-out", "duration-1000");
        dropdownOptions.classList.remove("transform", "opacity-0" , "scale-95");
        dropdownOptions.classList.add("transform", "opacity-100", "scale-100");              
        this.#dropdownOptionsState = true;
    }
}.bind(this));
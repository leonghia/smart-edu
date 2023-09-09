class AdminSidebarService {


    constructor() {
    }

    overlaySidebar() {
        document.querySelector(".se-sidebar").style.zIndex = 40;
    }

    unOverlaySidebar() {
        document.querySelector(".se-sidebar").removeAttribute("style");
    }
}

export default new AdminSidebarService();
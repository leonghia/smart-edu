import authService from "./services/auth.service.js";
import { getToken } from "./helpers/token.helper.js";
import { data, getStudents, state } from "./app.store.js";
import dataService from "./services/data.service.js";


export class AppComponent extends HTMLElement {

    // Dung de tao ra the <app-root> chua duoc dua vao DOM
    constructor() {
        super();  // super là contructor trong class cha (HTMLlement)
    }

    // Kich hoat khi <app-root> duoc dua vao DOM
    connectedCallback() {
        const token = getToken();
        if (!token) {
            // neu token khong ton tai
            this.innerHTML = `<app-login></app-login>`;
        } else {
            dataService.getCurrentUser()
                .then(res => {
                    data.currentUser = res.data;
                    const userType = data.currentUser.type;
                    switch (userType) {
                        case 0:
                            this.innerHTML = "<admin-dashboard></admin-dashboard>";
                            break;
                        case 1:
                            dataService.getStudents()
                                .then(res => {
                                    const students = res.data;
                                    data.currentUser.student = students.find(s => s.user.id == data.currentUser.id);     
                                    this.innerHTML = "<student-dashboard></student-dashboard>";        
                                });                                          
                            break;
                        case 2:
                            this.innerHTML = "<parent-dashboard></parent-dashboard>";
                            break;
                        case 3:
                            this.innerHTML = "<teacher-dashboard></teacher-dashboard>";
                            break;
                    }
                })
                .catch(err => {
                    console.error(err);
                });
        }
    }

    // Kich hoat khi <app-root> bi xoa khoi DOM
    disconnectedCallback() {

    }

    renderAdminDashboard() {

    }
}

customElements.define("app-root", AppComponent);
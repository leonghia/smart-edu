import authService from "./services/auth.service.js";
import { getToken } from "./helpers/token.helper.js";

export class AppComponent extends HTMLElement {

    // Dung de tao ra the <app-root> chua duoc dua vao DOM
    constructor() {
        super();  // super là contructor trong class cha (HTMLlement)
    }

    // Kich hoat khi <app-root> duoc dua vao DOM
    connectedCallback() {
        if (true) {
            // neu token khong ton tai
            this.innerHTML = `<app-login></app-login>`;
        } else {
            Promise.resolve({data: {type: 0}})
                .then(res => {
                    const user = res.data;
                    switch (user.type) {
                        case 0:
                            this.innerHTML = "<admin-dashboard></admin-dashboard>";
                            break;
                        case 1:
                            this.innerHTML = "<student-dashboard></student-dashboard>";
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
import { async } from "regenerator-runtime";
import authService from "./services/auth.service.js";

export class AppComponent extends HTMLElement {
    constructor() {
        super();
    }

    async connectedCallback() {
        // Kiem tra xem token co ton tai tren trinh duyet (LocalStorage)
        if (!authService._token) {
            // Neu khong co, hien thi trang dang nhap
            this.#renderLogin();
        } else {
            // Kiem tra xem token con han khong (gui ve server)
            try {
                const currentUser = await authService.getCurrentUser();
                console.log(currentUser);
                //
            } catch (err) {
                console.error("Token khong hop le hoac da het han.");
            }

        }
    }

    disconnectedCallback() {

    }

    #renderLogin() {
        this.innerHTML = `
            <app-login></app-login>
        `;
    }
}

customElements.define("app-root", AppComponent);
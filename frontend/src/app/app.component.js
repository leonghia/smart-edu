import authService from "./services/auth.service.js";

export class AppComponent extends HTMLElement {
  constructor() {
    super();
  }

  async connectedCallback() {
    //kiemtra xem token co ton tai tren trinh duyet hay khong
    if (!authService._token) {
      //neu k co -> hien thi trang dang nhap
      this.#renderLogin();
    } else {
      //kiem tra token con han hay khong -> gui ve sever
      try {
        const currentUser = await authService.getCurrentUser();
        console.log(currentUser);
        //
      } catch (err) {
        console.error("token k hop le hoac de het han");
      }
    }
  }

  disconnectedCallback() {}

  #renderLogin() {
    this.innerHTML = `
    <app-login></app-login>
    `;
  }
}

customElements.define("app-root", AppComponent);

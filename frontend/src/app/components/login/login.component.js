export class LoginComponent extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.innerHTML = `<p class="text-3xl font-bold text-indigo-500"></p>`;
  }

  disconnectedCallBack() { }
}

customElements.define("app-login", LoginComponent);

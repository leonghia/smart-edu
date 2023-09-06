export class AppComponent extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {}

  disconnectedCallback() {}
}

customElements.define("app-root", AppComponent);

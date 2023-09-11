import authService from "../../services/auth.service.js";
import { USERNAME_REQUIRED_MSG, PWD_REQUIRED_MSG, INVALID_CRE_MSG } from "../../app.config.js";
import { saveToken, saveTokenToSession } from "../../helpers/token.helper.js";


export class LoginComponent extends HTMLElement {

  #usernameInput;
  #passwordInput;
  #loginBtn;
  #rememberMeInput;
  #isRememberMe = false;
  constructor() {
    super();
  }



  connectedCallback() {
    this.innerHTML = this.#render();
    this.#usernameInput = document.querySelector("#username");
    this.#passwordInput = document.querySelector("#password");
    this.#loginBtn = document.querySelector("#se_login_btn");
    this.#rememberMeInput = document.querySelector("#remember-me");

    this.#rememberMeInput.addEventListener("click", function () {
      this.#isRememberMe = !this.#isRememberMe;

    }.bind(this));


    this.#loginBtn.addEventListener("click", function () {

      if (this.#usernameInput.value.trim().length === 0 && !this.#usernameInput.classList.contains("text-fuchsia-400")) {
        this.#showError(this.#usernameInput, USERNAME_REQUIRED_MSG);

      }

      if (this.#passwordInput.value.trim().length === 0 && !this.#passwordInput.classList.contains("text-fuchsia-400")) {
        this.#showError(this.#passwordInput, PWD_REQUIRED_MSG);
      }
      if (this.#usernameInput.value.trim().length === 0 || this.#passwordInput.value.trim().length === 0) {
        return;
      }

      authService.login({ username: this.#usernameInput.value, password: this.#passwordInput.value })
        .then(data => {
          this.#loginBtn.children[0].remove();
          if (this.#isRememberMe) {
            saveToken(data.data);
          } else {
            saveTokenToSession(data.data);
          }

          location.reload();
        })

      this.#loginBtn.insertAdjacentHTML("afterbegin", `<loading-spinner></loading-spinner>`);
      this.#loginBtn.children[1].textContent = "Singning in";

    }.bind(this));


    this.#usernameInput.addEventListener("input", function () {

      if (this.#usernameInput.value.trim().length === 0 && !this.#usernameInput.classList.contains("text-fuchsia-400")) {
        this.#showError(this.#usernameInput, USERNAME_REQUIRED_MSG);
      } else {
        this.#hideError(this.#usernameInput, USERNAME_REQUIRED_MSG);
      }
    }.bind(this));

    this.#passwordInput.addEventListener("input", function () {

      if (this.#passwordInput.value.trim().length === 0 && !this.#passwordInput.classList.contains("text-fuchsia-400")) {
        this.#showError(this.#passwordInput, USERNAME_REQUIRED_MSG);
      } else {
        this.#hideError(this.#passwordInput, USERNAME_REQUIRED_MSG);
      }
    }.bind(this));
  }

  #showError(input, errorMessage) {
    input.classList.remove("text-white");
    input.classList.add("text-fuchsia-400");
    input.classList.add("outline", "outline-offset-0", "outline-1", "outline-fuchsia-500");
    const p = document.createElement("p");
    p.classList.add("mt-2", "text-fuchsia-400", "text-sm");
    p.textContent = errorMessage;
    input.after(p);
  }

  #hideError(input) {
    input.classList.remove("text-fuchsia-400");
    input.classList.add("text-white");
    input.classList.remove("outline", "outline-offset-0", "outline-1", "outline-fuchsia-500");
    input.nextElementSibling && input.nextElementSibling.remove();
  }

  disconnectedCallback() {

  }

  #render() {
    return `
      <div class="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
      <div class="sm:mx-auto sm:w-full sm:max-w-sm">
        <img class="mx-auto h-10 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=fuchsia&shade=500" alt="SmartEdu login page">
        <h2 class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-white">Sign in to SmartEdu</h2>
      </div>
    
      <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <form class="space-y-6" action="#" method="POST">
          <div>
            <label for="username" class="block text-sm font-medium leading-6 text-white">Username</label>
            <div class="mt-2 se-username-container">
              <input id="username" name="username" type="text" autocomplete="username" class="peer block w-full rounded-md border-0 bg-white/5 py-1.5 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-fuchsia-500 sm:text-sm sm:leading-6">
              
            </div>
          </div>
    
          <div>
            <div class="flex items-center justify-between">
              <label for="password" class="block text-sm font-medium leading-6 text-white">Password</label>            
            </div>
            <div class="mt-2 se-password-container">
              <input id="password" name="password" type="password" autocomplete="current-password" class="block w-full rounded-md border-0 bg-white/5 py-1.5 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-fuchsia-500 sm:text-sm sm:leading-6">
            </div>
          </div>
          
          <div class="flex items-center justify-between">
            <div class="flex items-center">
              <input id="remember-me" name="remember-me" type="checkbox" class="h-4 w-4 rounded border-gray-300 text-fuchsia-600 focus:ring-fuchsia-600">
              <label for="remember-me" class="ml-3 block text-sm leading-6 text-white">Remember me</label>
            </div>
            <div class="text-sm">
                <a href="#" class="font-semibold text-fuchsia-400 hover:text-fuchsia-300">Forgot password?</a>
            </div>
          </div>
    
          <div>
            <button id="se_login_btn" type="button" class="flex w-full justify-center items-center rounded-md bg-fuchsia-500 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-fuchsia-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-500">
              
              <span>Sign in</span>
            </button>
          </div>
        </form>
    
        <p class="mt-10 text-center text-sm text-gray-400">
          Not a member?
          <a href="#" class="font-semibold leading-6 text-fuchsia-400 hover:text-fuchsia-300">Request a new account</a>
        </p>
      </div>
    </div>
      `;
  }
}

customElements.define("app-login", LoginComponent);
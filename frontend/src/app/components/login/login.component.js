import authService from "../../services/auth.service.js";
import { USERNAME_REQUIRED_MSG, PWD_REQUIRED_MSG, INVALID_CRE_MSG } from "../../app.config.js";

export class LoginComponent extends HTMLElement {

  #usernameInput;
  #passwordInput;
  #loginBtn;

  constructor() {
    super();
  }

  connectedCallback() {
    this.innerHTML = this.#render();
    this.#usernameInput = document.querySelector("#username");
    this.#passwordInput = document.querySelector("#password");
    this.#loginBtn = document.querySelector("#se_login_btn");
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
        <img class="mx-auto h-10 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=fuchsia&shade=500" alt="Your Company">
        <h2 class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-white">Sign in to your SmartEdu</h2>
      </div>
    
      <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <form class="space-y-6" action="#" method="POST">
          <div>
            <label for="username" class="block text-sm font-medium leading-6 text-white">Username</label>
            <div class="mt-2 se-username-container">
              <input id="username" name="username" type="text" autocomplete="username" required class="peer block w-full rounded-md border-0 bg-white/5 py-1.5 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-fuchsia-500 sm:text-sm sm:leading-6">
              
            </div>
          </div>
    
          <div>
            <div class="flex items-center justify-between">
              <label for="password" class="block text-sm font-medium leading-6 text-white">Password</label>            
            </div>
            <div class="mt-2 se-password-container">
              <input id="password" name="password" type="password" autocomplete="current-password" required class="block w-full rounded-md border-0 bg-white/5 py-1.5 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-fuchsia-500 sm:text-sm sm:leading-6">
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
              <svg aria-hidden="true" role="status" class="inline w-4 h-4 mr-3 text-white animate-spin" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="#E5E7EB"/>
              <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="currentColor"/>
              </svg>
              Sign in. . . . .
            </button>
          </div>
        </form>
    
        <p class="mt-10 text-center text-sm text-gray-400">
          Not a member?
          <a href="#" class="font-semibold leading-6 text-fuchsia-400 hover:text-fuchsia-300">Request a new account to create</a>
        </p>
      </div>
    </div>
      `;
  }
}

customElements.define("app-login", LoginComponent);
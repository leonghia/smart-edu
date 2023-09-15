export class StudentExtraClassStatComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
        
<div class="border-b border-gray-500 dark:border-gray-600 border-dashed pb-5">
    <h3 class="text-base font-semibold leading-6 text-gray-900">Your Extra Classes</h3>
    <p class="mt-2 max-w-4xl text-sm text-gray-500">Listing all the extra classes you are joining, recently registered or past extra classes you had attended before. Current classes are marked as active and finished or canceled classes are marked as corresponding.</p>
</div>
<ul role="list" class="divide-y divide-dashed divide-gray-500 dark:divide-gray-600">
  <li class="flex items-center justify-between gap-x-6 py-5">
    <div class="min-w-0">
      <div class="flex items-start gap-x-3">
        <p class="text-sm font-semibold leading-6 text-gray-900">Maths M2208-10</p>
        <p class="rounded-md whitespace-nowrap mt-0.5 px-1.5 py-0.5 text-xs font-medium ring-1 ring-inset text-green-700 bg-green-50 ring-green-600/20">Complete</p>
      </div>
      <div class="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
        <p class="whitespace-nowrap">Due on <time datetime="2023-03-17T00:00Z">March 17, 2023</time></p>
        <svg viewBox="0 0 2 2" class="h-0.5 w-0.5 fill-current">
          <circle cx="1" cy="1" r="1" />
        </svg>
        <p class="truncate">Created by teacher Nguyen Duy Hoang</p>
      </div>
    </div>
    <div class="flex flex-none items-center gap-x-4">
      
      <div class="relative flex-none">
        <button type="button" class="-m-2.5 block p-2.5 text-gray-500 hover:text-gray-900" id="options-menu-0-button" aria-expanded="false" aria-haspopup="true">
          <span class="sr-only">Open options</span>
          <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
            <path d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z" />
          </svg>
        </button>

        <!--
          Dropdown menu, show/hide based on menu state.

          Entering: "transition ease-out duration-100"
            From: "transform opacity-0 scale-95"
            To: "transform opacity-100 scale-100"
          Leaving: "transition ease-in duration-75"
            From: "transform opacity-100 scale-100"
            To: "transform opacity-0 scale-95"
        -->
        <div class="opacity-0 absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="options-menu-0-button" tabindex="-1">
          <!-- Active: "bg-gray-50", Not Active: "" -->
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-0">Edit<span class="sr-only">, GraphQL API</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-1">Move<span class="sr-only">, GraphQL API</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-2">Delete<span class="sr-only">, GraphQL API</span></a>
        </div>
      </div>
    </div>
  </li>
  <li class="flex items-center justify-between gap-x-6 py-5">
    <div class="min-w-0">
      <div class="flex items-start gap-x-3">
        <p class="text-sm font-semibold leading-6 text-gray-900">Literature A2208-10</p>
        <p class="rounded-md whitespace-nowrap mt-0.5 px-1.5 py-0.5 text-xs font-medium ring-1 ring-inset text-blue-600 bg-blue-100 ring-blue-600/10">In progress</p>
      </div>
      <div class="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
        <p class="whitespace-nowrap">Due on <time datetime="2023-05-05T00:00Z">May 5, 2023</time></p>
        <svg viewBox="0 0 2 2" class="h-0.5 w-0.5 fill-current">
          <circle cx="1" cy="1" r="1" />
        </svg>
        <p class="truncate">Created by teacher Trinh Quang Hoa</p>
      </div>
    </div>
    <div class="flex flex-none items-center gap-x-4">
      
      <div class="relative flex-none">
        <button type="button" class="-m-2.5 block p-2.5 text-gray-500 hover:text-gray-900" id="options-menu-1-button" aria-expanded="false" aria-haspopup="true">
          <span class="sr-only">Open options</span>
          <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
            <path d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z" />
          </svg>
        </button>

        <!--
          Dropdown menu, show/hide based on menu state.

          Entering: "transition ease-out duration-100"
            From: "transform opacity-0 scale-95"
            To: "transform opacity-100 scale-100"
          Leaving: "transition ease-in duration-75"
            From: "transform opacity-100 scale-100"
            To: "transform opacity-0 scale-95"
        -->
        <div class="opacity-0 absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="options-menu-1-button" tabindex="-1">
          <!-- Active: "bg-gray-50", Not Active: "" -->
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-1-item-0">Edit<span class="sr-only">, New benefits plan</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-1-item-1">Move<span class="sr-only">, New benefits plan</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-1-item-2">Delete<span class="sr-only">, New benefits plan</span></a>
        </div>
      </div>
    </div>
  </li>
  <li class="flex items-center justify-between gap-x-6 py-5">
    <div class="min-w-0">
      <div class="flex items-start gap-x-3">
        <p class="text-sm font-semibold leading-6 text-gray-900">English M2208-10</p>
        <p class="rounded-md whitespace-nowrap mt-0.5 px-1.5 py-0.5 text-xs font-medium ring-1 ring-inset text-blue-600 bg-blue-100 ring-blue-600/10">In progress</p>
      </div>
      <div class="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
        <p class="whitespace-nowrap">Due on <time datetime="2023-05-25T00:00Z">May 25, 2023</time></p>
        <svg viewBox="0 0 2 2" class="h-0.5 w-0.5 fill-current">
          <circle cx="1" cy="1" r="1" />
        </svg>
        <p class="truncate">Created by teacher Nguyen Duy Hoang</p>
      </div>
    </div>
    <div class="flex flex-none items-center gap-x-4">
      
      <div class="relative flex-none">
        <button type="button" class="-m-2.5 block p-2.5 text-gray-500 hover:text-gray-900" id="options-menu-2-button" aria-expanded="false" aria-haspopup="true">
          <span class="sr-only">Open options</span>
          <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
            <path d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z" />
          </svg>
        </button>

        <!--
          Dropdown menu, show/hide based on menu state.

          Entering: "transition ease-out duration-100"
            From: "transform opacity-0 scale-95"
            To: "transform opacity-100 scale-100"
          Leaving: "transition ease-in duration-75"
            From: "transform opacity-100 scale-100"
            To: "transform opacity-0 scale-95"
        -->
        <div class="opacity-0 absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="options-menu-2-button" tabindex="-1">
          <!-- Active: "bg-gray-50", Not Active: "" -->
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-2-item-0">Edit<span class="sr-only">, Onboarding emails</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-2-item-1">Move<span class="sr-only">, Onboarding emails</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-2-item-2">Delete<span class="sr-only">, Onboarding emails</span></a>
        </div>
      </div>
    </div>
  </li>
  <li class="flex items-center justify-between gap-x-6 py-5">
    <div class="min-w-0">
      <div class="flex items-start gap-x-3">
        <p class="text-sm font-semibold leading-6 text-gray-900">Maths M2208-10</p>
        <p class="rounded-md whitespace-nowrap mt-0.5 px-1.5 py-0.5 text-xs font-medium ring-1 ring-inset text-blue-600 bg-blue-100 ring-blue-600/10">In progress</p>
      </div>
      <div class="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
        <p class="whitespace-nowrap">Due on <time datetime="2023-06-07T00:00Z">June 7, 2023</time></p>
        <svg viewBox="0 0 2 2" class="h-0.5 w-0.5 fill-current">
          <circle cx="1" cy="1" r="1" />
        </svg>
        <p class="truncate">Created by teacher Trinh Quang Hoa</p>
      </div>
    </div>
    <div class="flex flex-none items-center gap-x-4">
      
      <div class="relative flex-none">
        <button type="button" class="-m-2.5 block p-2.5 text-gray-500 hover:text-gray-900" id="options-menu-3-button" aria-expanded="false" aria-haspopup="true">
          <span class="sr-only">Open options</span>
          <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
            <path d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z" />
          </svg>
        </button>

        <!--
          Dropdown menu, show/hide based on menu state.

          Entering: "transition ease-out duration-100"
            From: "transform opacity-0 scale-95"
            To: "transform opacity-100 scale-100"
          Leaving: "transition ease-in duration-75"
            From: "transform opacity-100 scale-100"
            To: "transform opacity-0 scale-95"
        -->
        <div class="opacity-0 absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="options-menu-3-button" tabindex="-1">
          <!-- Active: "bg-gray-50", Not Active: "" -->
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-3-item-0">Edit<span class="sr-only">, iOS app</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-3-item-1">Move<span class="sr-only">, iOS app</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-3-item-2">Delete<span class="sr-only">, iOS app</span></a>
        </div>
      </div>
    </div>
  </li>
  <li class="flex items-center justify-between gap-x-6 py-5">
    <div class="min-w-0">
      <div class="flex items-start gap-x-3">
        <p class="text-sm font-semibold leading-6 text-gray-900">Literature A2208-10</p>
        <p class="rounded-md whitespace-nowrap mt-0.5 px-1.5 py-0.5 text-xs font-medium ring-1 ring-inset text-red-600 bg-red-100 ring-red-600/20">Canceled</p>
      </div>
      <div class="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
        <p class="whitespace-nowrap">Due on <time datetime="2023-06-10T00:00Z">June 10, 2023</time></p>
        <svg viewBox="0 0 2 2" class="h-0.5 w-0.5 fill-current">
          <circle cx="1" cy="1" r="1" />
        </svg>
        <p class="truncate">Created by teacher Trinh Quang Hoa</p>
      </div>
    </div>
    <div class="flex flex-none items-center gap-x-4">
      
      <div class="relative flex-none">
        <button type="button" class="-m-2.5 block p-2.5 text-gray-500 hover:text-gray-900" id="options-menu-4-button" aria-expanded="false" aria-haspopup="true">
          <span class="sr-only">Open options</span>
          <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
            <path d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z" />
          </svg>
        </button>

        <!--
          Dropdown menu, show/hide based on menu state.

          Entering: "transition ease-out duration-100"
            From: "transform opacity-0 scale-95"
            To: "transform opacity-100 scale-100"
          Leaving: "transition ease-in duration-75"
            From: "transform opacity-100 scale-100"
            To: "transform opacity-0 scale-95"
        -->
        <div class="opacity-0 absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="options-menu-4-button" tabindex="-1">
          <!-- Active: "bg-gray-50", Not Active: "" -->
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-4-item-0">Edit<span class="sr-only">, Marketing site redesign</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-4-item-1">Move<span class="sr-only">, Marketing site redesign</span></a>
          <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-4-item-2">Delete<span class="sr-only">, Marketing site redesign</span></a>
        </div>
      </div>
    </div>
  </li>
</ul>
        `;
    }
}

customElements.define("student-ec-stat", StudentExtraClassStatComponent);
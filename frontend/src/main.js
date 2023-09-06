import "core-js/stable";
import "regenerator-runtime/runtime.js";

import "./app/app.module.js";

import authService from "./app/services/auth.service.js";

var response = await authService.getCurrentUser();
console.log(response);

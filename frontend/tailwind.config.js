/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}"],
  theme: {
    // colors: {
    //   "indigo": "#f472b6",
    // },
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
}


export const login = async function (url = "", dataDTO) {
  const response = await fetch(url, {
    method: "POST", //cho phep truyen du lieu den sever
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
    },
    redirect: "follow",
    referrerPolicy: "no-referrer",
    body: JSON.stringify(dataDTO),
  });
  return response.json();
};

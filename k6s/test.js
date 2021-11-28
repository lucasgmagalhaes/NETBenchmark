import http from "k6/http";
import { check, sleep } from "k6";

export const options = {
  stages: [
    { duration: "30s", target: 10 }, // below normal load
    { duration: "4m", target: 5000 },
    { duration: "1m", target: 0 }, // scale down. Recovery stage.
  ],
};

function randon(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min;
}

export default function () {
  http.get(`https://localhost:5001/employee?fetchSize=${randon(10, 200)}&minId=${randon(1, 13000)}`);
  sleep(1);
}

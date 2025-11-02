import http from "k6/http";
import { check, sleep } from "k6";

export let options = {
    vus: 50,          
    iterations: 1000, 
};

export default function () {
    const url = "https://localhost:7065/api/v1/Task"; 

    const payload = JSON.stringify({
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "name": "string",
        "cronExpression": "string",
        "taskType": "string",
        "createdAt": "2025-11-02T07:35:03.392Z",
        "status": 0
    });

    const params = {
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
        },
    };

    let res = http.post(url, payload, params);

    check(res, {
        "status is 200": (r) => r.status === 200,
        "response not empty": (r) => r.body && r.body.length > 0,
    });

}

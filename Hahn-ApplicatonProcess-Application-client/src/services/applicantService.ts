import { HttpClient, json } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";
import { api } from "../config/api";

@inject(HttpClient)
export class ApplicantService {
  private http: HttpClient;
  applicants: [];
  countries: [];

  constructor(http: HttpClient) {
    http.configure((config) => {
      config
        .withBaseUrl(api.baseUrl)
        .withDefaults({
          credentials: "same-origin",
          headers: {
            Accept: "application/json",
            "X-Requested-With": "Fetch",
          },
        })
        .withInterceptor({
          request(request) {
            console.log(`Requesting ${request.method} ${request.url}`);
            return request; // you can return a modified Request, or you can short-circuit the request by returning a Response
          },
          response(response) {
            console.log(`Received ${response.status} ${response.url}`);
            return response; // you can return a modified Response
          },
        });
    });
    this.http = http;
  }

  addApplicant(applicant) {
    return this.http
      .fetch("applicant", {
        method: "post",
        body: json(applicant),
      })
      .then((response) => response.json())
      .then((responseMessage) => {
        return responseMessage;
      })
      .catch((error) => {
        console.log("Error saving applicant", error);
      });
  }

  deleteApplicant(id) {
    return this.http
      .fetch(`applicant/${id}`, {
        method: "delete",
      })
      .then((response) => response.json())
      .then((responseMessage) => {
        return responseMessage;
      })
      .catch((error) => {
        console.log("Error deleting applicant", error);
      });
  }

  updateApplicant(applicant) {
    return this.http
      .fetch(`applicant/${applicant.id}`, {
        method: "put",
        body: json(applicant),
      })
      .then((response) => response.json())
      .then((responseMessage) => {
        return responseMessage;
      })
      .catch((error) => {
        console.log("Error updating applicant", error);
      });
  }

  getApplicant() {
    return this.http
      .fetch("applicant", {
        method: "get",
      })
      .then((response) => response.json())
      .then((applicants) => {
        return applicants;
      })
      .catch((error) => {
        console.log("Error retrieving applicant.", error);
        return [];
      });
  }

  getApplicantById(id) {
    return this.http
      .fetch(`applicant/${id}`)
      .then((response) => response.json())
      .then((applicants) => {
        return applicants;
      })
      .catch((error) => {
        console.log("Error retrieving applicant.", error);
        return [];
      });
  }

  getCountry() {
    return this.http
      .fetch("applicant/GetCountry", {
        method: "get",
      })
      .then((response) => response.json())
      .then((countries) => {
        debugger;
        console.log("Fetching... ", countries);
        localStorage.setItem("countries", JSON.stringify(countries));

        return countries;
      })

      .catch((error) => {
        console.log("Error retrieving countires.", error);
        return [];
      });
  }
}

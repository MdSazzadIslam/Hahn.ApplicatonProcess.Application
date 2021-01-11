import { PLATFORM } from "aurelia-framework";
import { Router, RouterConfiguration } from "aurelia-router";

export class App {
  router: Router | undefined;
  configureRouter(config: RouterConfiguration, router: Router) {
    config.title = "Hahn Applicant Process";
    config.options.pushState = true;
    //config.options.root = "/";
    config.map([
      {
        route: ["", "applicant-add"],
        name: "AddApplicant",
        moduleId: PLATFORM.moduleName("views/addApplicant"),
        title: "Add New Applicant",
        nav: true,
      },

      {
        route: ["applicant-list"],
        name: "ApplicantList",
        moduleId: PLATFORM.moduleName("views/applicantList"),
        title: "Applicant List",
        nav: true,
      },

      {
        route: ["applicant-edit/:id"],
        name: "EditApplicant",
        title: "Edit Applicant",
        moduleId: PLATFORM.moduleName("views/editApplicant"),
      },
    ]);

    this.router = router;
  }
}

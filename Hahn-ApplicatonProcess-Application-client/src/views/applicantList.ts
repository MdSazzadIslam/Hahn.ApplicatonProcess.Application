import { inject, bindable } from "aurelia-framework";
import { EventAggregator } from "aurelia-event-aggregator";
import { Router } from "aurelia-router";
import { ApplicantService } from "../services/applicantService";
import { DialogService } from "aurelia-dialog";
import { Dialog } from "./dialog";
import { I18N } from "aurelia-i18n";

@inject(Router, ApplicantService, DialogService, I18N, EventAggregator)
export class ApplicantList {
  private i18n = [I18N];
  private applicantService: ApplicantService;
  private router: Router;
  private dlg: DialogService;
  private ea: EventAggregator;
  title: any;
  applicants: [];

  searchBy: number;
  selectedId: any;

  constructor(router, applicantService, dlg, i18n, ea) {
    this.router = router;
    this.applicantService = applicantService;
    this.dlg = dlg;
    this.i18n = i18n;

    this.ea = ea;
    this.title = "Applicant List";
  }

  @bindable
  action = async (id) => {
    await this.applicantService.deleteApplicant(id).then(async (response) => {
      if (response.statusCode != 201) {
        alert("Something went wrong!!!");
      }
      await this.search();
    });
    return true;
  };

  @bindable
  msg = "Are you sure";

  activate() {
    try {
      this.search();
    } catch (error) {
      console.log(error);
    }
  }

  async search() {
    debugger;
    await this.applicantService
      .getApplicant()
      .then((response) => (this.applicants = response));
    console.log(this.applicants);
    return true;
  }

  async searchById(id) {
    debugger;
    await this.applicantService
      .getApplicantById(id)
      .then((response) => (this.applicants = response));
    console.log(this.applicants);
    return true;
  }

  removeApplicant = async (id) => {
    debugger;
    this.dlg
      .open({
        viewModel: Dialog,
        model: this.msg,
      })
      .then(async (result) => {
        if (!result.wasCancelled) {
          await this.applicantService.deleteApplicant(id);
          await this.search();
        } else {
          console.log("cancelled");
        }
      });
  };
}

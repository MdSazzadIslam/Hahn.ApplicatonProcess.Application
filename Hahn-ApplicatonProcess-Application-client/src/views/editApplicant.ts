import {
  inject,
  CompositionTransaction,
  CompositionTransactionNotifier,
} from "aurelia-framework";
import { Router } from "aurelia-router";
import { EventAggregator } from "aurelia-event-aggregator";
import { ApplicantService } from "../services/applicantService";
import { Applicant } from "../entities/applicant";
import { DialogService } from "aurelia-dialog";
import { Dialog } from "./dialog";

import { I18N } from "aurelia-i18n";

import {
  ValidationControllerFactory,
  ValidationRules,
} from "aurelia-validation";

import { BootstrapFormRenderer } from "../resources/bootstrap-form-renderer";

@inject(
  ApplicantService,
  ValidationControllerFactory,
  CompositionTransaction,
  Router,
  I18N,
  DialogService,
  EventAggregator,
  Applicant
)
export class EditApplicant {
  private applicantervice: ApplicantService;
  private controllerFactory: ValidationControllerFactory;
  private notifier: CompositionTransactionNotifier;
  private router: Router;
  private i18N: I18N;
  private dialogService: DialogService;
  private ea: EventAggregator;
  controller = null;
  title: any;
  validation: any;
  standardGetMessage: any;
  applicant: any;
  data: any;

  constructor(
    applicantervice,
    controllerFactory,
    compositionTransaction,
    router,
    i18N,
    dialogService,
    ea,
    private app: Applicant
  ) {
    this.applicantervice = applicantervice;
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapFormRenderer());
    this.notifier = compositionTransaction.enlist();
    this.router = router;
    this.title = "Edit Applicant";
    this.i18N = i18N;
    this.dialogService = dialogService;
    this.ea = ea;
    this.applicant = app;
  }
  attached(): void {}
  action(): void {
    this.clearData();
  }

  public openDialog() {
    this.dialogService
      .open({
        viewModel: Dialog,
        model: "are you really sure to reset all the data",
      })
      .whenClosed()
      .then((respose) => {
        this.action();
      });
  }

  isChecked(value) {
    this.applicant.hired = value;
  }

  clearData() {
    this.applicant = null;
    this.router.navigateToRoute("ApplicantList");
  }

  //enable send button when form validation is done
  get canSave() {
    return (
      this.applicant.name &&
      this.applicant.familyName &&
      this.applicant.address &&
      this.applicant.countryOfOrigin &&
      this.applicant.emailAdress &&
      this.applicant.age >= 20 &&
      this.applicant.age <= 60
    );
  }

  async searchById(id) {
    debugger;
    await this.applicantervice
      .getApplicantById(id)
      .then((response) => (this.data = response));
    this.data.forEach((element) => (this.applicant = element));
    console.log(this.applicant);
  }

  checkValidcountry = (countryName) => {
    try {
      var data = JSON.parse(localStorage.getItem("countries"));

      if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
          var cName = data[i];
          console.log(cName);
          if (
            cName.name.toLowerCase() == countryName.toLowerCase() ||
            cName.name.toUpperCase() == countryName.toUpperCase()
          ) {
            var valid = 1;
            break;
          }
        }
      }
    } catch (error) {
      console.log(error);
    }
    return valid;
  };

  activate = async (params) => {
    try {
      if (localStorage.getItem("countries") === null) {
        await this.applicantervice.getCountry();
      }
      await this.searchById(params.id);
      this.notifier.done();
      this.setupValidation();
    } catch (error) {
      console.log(error);
    }
  };

  setupValidation() {
    //Custom validation for checking between two numbers
    ValidationRules.customRule(
      "integerRange",
      (value, obj, min, max) => {
        var num = Number.parseInt(value);
        return (
          num === null ||
          num === undefined ||
          (Number.isInteger(num) && num >= min && num <= max)
        );
      },
      "${$displayName} must be an integer between ${$config.min} and ${$config.max}.",
      (min, max) => ({ min, max })
    );

    //validation rules starts from here
    ValidationRules.ensure("name")
      .displayName("name")
      .required()
      .minLength(5)
      .withMessage("Name at least 5 Characters")

      .ensure("familyName")
      .displayName("familyName")
      .required()
      .minLength(5)
      .withMessage("FamilyName - at least 5 Characters")

      .ensure("address")
      .required()
      .minLength(10)
      .withMessage("Address - at least 10 Characters")

      .ensure("countryOfOrigin")
      .required()
      .withMessage("Please select country")

      .ensure("emailAdress")
      .required()
      .email()
      //.matches(RegExp("^(\\w+.*)(\\@)(\\w+.*)$", "gi"))
      .withMessage("EmailAdress is required")

      .ensure("age")
      .required()
      .satisfiesRule("integerRange", 20, 60)
      .withMessage("Age – must be between 20 and 60")

      .on(this.applicant);
  }

  //this function will fire when user click the submit button
  execute = async () => {
    try {
      debugger;
      var res = await this.controller.validate();

      if (res.valid) {
        this.update();
      }
    } catch (error) {
      console.log(error);
    }
  };

  update = async () => {
    var result = this.checkValidcountry(this.applicant.countryOfOrigin);
    try {
      if (result == 1) {
        var v = parseInt(this.applicant.age);
        this.applicant.age = v;
        try {
          await this.applicantervice
            .updateApplicant(this.applicant)
            .then((response) => {
              debugger;
              if (response.statusCode == 201) {
                this.router.navigateToRoute("ApplicantList");
              } else {
                alert("Something went wrong!!!");
              }
            });
        } catch (error) {
          console.log(error);
        }
      } else {
        alert("Country not found");
      }
    } catch (error) {
      console.log(error);
    }
  };
}

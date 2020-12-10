import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  readonly ApiURL = 'https://localhost:44369'

  registerModel = this.fb.group({
    Username: new FormControl('', [Validators.required]),
    Passwords: this.fb.group({
      Password: new FormControl('', [Validators.required, Validators.pattern('(?=^[^\s]{6,}$)(?=.*\d)(?=.*[a-zA-Z])')]),
      ConfirmPassword: new FormControl('', [Validators.required])
    }, {
      validators: this.comparePasswords
    }),
    EmailAddress: new FormControl('', [Validators.required, Validators.pattern('/\S+@\S+\.\S+/')]),
    Address: new FormControl(''),
    PhoneNumber: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.minLength(10)]),
    BankAccountNumber: new FormControl('', [Validators.required, Validators.pattern('(^BG)([0-9]{2})([A-Z]{4})([0-9]{14}$)')])
  })

  comparePasswords(fg: FormGroup) {
    let confirmedPassword = fg.get('ConfirmPassword')

    if (confirmedPassword.errors === null || 'passwordMismatch' in confirmedPassword.errors) {
      if (fg.get('Password').value != confirmedPassword.value) {
        confirmedPassword.setErrors({ passwordMismatch: true })
      } else {
        confirmedPassword.setErrors(null)
      }
    }
  }

  register() {
    let registrationUser = {
      Username: this.registerModel.value.Username,
      Password: this.registerModel.value.Passwords.Password,
      EmailAddress: this.registerModel.value.EmailAdress,
      Address: this.registerModel.value.Address,
      PhoneNumber: this.registerModel.value.PhoneNumber,
      BankAccountNumber: this.registerModel.value.BankAccountNumber
    }

    return this.http.post(this.ApiURL + 'User/Registration', registrationUser)
  }

  login(data) {
    return this.http.post(this.ApiURL + '/User/Login', data)
  }
}

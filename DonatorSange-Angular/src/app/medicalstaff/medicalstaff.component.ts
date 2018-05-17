import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { DataSource } from '@angular/cdk/collections';
import { DonorService } from '../services/donor.service';
import { Donor } from '../models/donor';
import { HttpClient } from '@angular/common/http';
import { DialogVerifyEligibility } from '../dialogs/eligibilityVerification';

@Component({
  selector: 'medicalstaff',
  templateUrl: './medicalstaff.component.html',
  styleUrls: ['./medicalstaff.component.css'],
  providers:[DonorService]
})
export class MedicalstaffComponent implements OnInit {

  displayedColumns = ['firstName', 'lastName', 'county','city','phone','date','bloodType','actions'];
  database: Database | null;
  dataSource: DataSourceDonor | null;
  selectedDonor: number;
  user = JSON.parse(localStorage.getItem('myUser'));
  eligibilityVerification=false;
 

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;

  constructor(http: HttpClient, private DonorService: DonorService, public dialog: MatDialog, private router:Router) {
    this.database = new Database(http, this.DonorService,router);
  }


  eligibilityDialog(id:number) {
        let dialogRef;
        dialogRef = this.dialog.open(DialogVerifyEligibility, { width: '50%',height:'80%',data:{donorId:id} });
      }

  isEligible(donorId){
    let donor = this.database.getDonor(donorId);
    let year=1000*60*60*24*365;
    let donorTime=new Date(donor.donorData.birthdate).getTime();
    let actualTime=new Date().getTime();
    let birthDateValidation = (donorTime+18*year<actualTime&&donorTime+60*year>actualTime)
    let weightValidation=(donor.donorData.weight>50);
    let bloodPreassureValidation=(donor.donorData.bloodPressure>100&&donor.donorData.bloodPressure<180);
    let heartBeatValidation=(donor.donorData.heartbeat>60&&donor.donorData.heartbeat<100);
    let finalResult=(birthDateValidation&&weightValidation&&heartBeatValidation&&bloodPreassureValidation&&!donor.donorData.interventions&&!donor.donorData.feminineProblems&&!donor.donorData.junkFood&&!donor.donorData.onDrugs&&!donor.donorData.diseases);
    return finalResult;
  }


  hasRequest(request){
    return (request  != null );
  }
    

  dateToString(date: Date): string {
    var currentTime = new Date(date);
    var month = currentTime.getMonth();
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var retdate = day + "." + month + "." + year;
    return retdate;
  }

  dateToHour(date: Date): string {
    var currentTime = new Date(date);
    var hour = currentTime.getHours();
    var minutes = currentTime.getMinutes();
    return hour + ":" + minutes;
  }

  daysDifference(d1: Date, d2: Date) {
    var oneDay = 1000 * 60 * 60 * 24;
    var d1t = d1.getTime();
    var d2t = d2.getTime();

    var difference = d1t - d2t;
    return Math.round(difference / oneDay);
  }


  isDoctor(role){
    return (role=='Doctor');
  }

  isPatient(role){
    return (role=='Patient');
  }

  ngOnInit() {
    this.dataSource = new DataSourceDonor(this.database, this.paginator, this.sort);
    Observable.fromEvent(this.filter.nativeElement, 'keyup')
      .debounceTime(150)
      .distinctUntilChanged()
      .subscribe(() => {
        if (!this.dataSource) { return; }
        this.dataSource.filter = this.filter.nativeElement.value;
      });

  }
}

/** An example database that the data source uses to retrieve data for the table. */
export class Database {
  user = JSON.parse(localStorage.getItem('myDonor'));

  /** Adds a new Donor to the database. */
  addDonors(membersToAdd: Array<Donor>) {
    for (let i = 0; i < membersToAdd.length; i++) {
      const copiedData = this.data.slice();
      copiedData.push(membersToAdd[i]);
      this.dataChange.next(copiedData);
    }
  }

  /** Stream that emits whenever the data has been modified. */
  dataChange: BehaviorSubject<Donor[]> = new BehaviorSubject<Donor[]>([]);
  get data(): Donor[] { return this.dataChange.value; }

  constructor(private http: HttpClient, DonorService: DonorService, private router:Router) {
    this.user = JSON.parse(localStorage.getItem('myUser'));
    DonorService.getDonors(this.user.medicalUnit.id)
      .subscribe(
        Donors => { this.addDonors(Donors) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        }
      )
  };

  getDonor(id: number): Donor {
    const Donors: Donor[] = this.data;
    const length: number = Donors.length;
    let i;
    for (i = 0; i < length; i++) {
      if (Donors[i].id == id)
        return Donors[i]
    }
    return null;
  }

}

/**
 * Data source to provide what data should be rendered in the table. Note that the data source
 * can retrieve its data in any way. In this case, the data source is provided a reference
 * to a common data base, Database. It is not the data source's responsibility to manage
 * the underlying data. Instead, it only needs to take the data and send the table exactly what
 * should be rendered.
 */
export class DataSourceDonor extends DataSource<any> {
  _filterChange = new BehaviorSubject('');
  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }
  constructor(private _database: Database, private _paginator: MatPaginator, private _sort: MatSort) {
    super();
  }
  filterLength: number = this._database.data.length;

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Donor[]> {
    const displayDataChanges = [
      this._database.dataChange,
      this._paginator.page,
      this._filterChange,
      this._sort.sortChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: Donor) => {
        let searchStr = item.user.firstName+item.user.lastName+item.address.county+item.address.city+item.phone;
        return searchStr.indexOf(this.filter.toLowerCase()) != -1;
      });
      this.filterLength = elements.length;
      return this.getSortedData(elements).splice(startIndex, this._paginator.pageSize);
    });
  }

  getSortedData(elements: Donor[]): Donor[] {
    const data = elements.slice();
    if (!this._sort.active || this._sort.direction == '') { return data; }

    return data.sort((a, b) => {
      let propertyA: number | string | Date | boolean = '';
      let propertyB: number | string | Date | boolean = '';

      switch (this._sort.active) {
        case 'firstName': [propertyA, propertyB] = [(a.user.firstName), (b.user.firstName)]; break;
        case 'lastName': [propertyA, propertyB] = [(a.user.lastName), (b.user.lastName)]; break;
        case 'county': [propertyA, propertyB] = [(a.address.county), (b.address.county)]; break;
        case 'city': [propertyA, propertyB] = [(a.address.city), (b.address.city)]; break;
        case 'phone': [propertyA, propertyB] = [(a.phone), (b.phone)]; break;
        case 'date': [propertyA, propertyB] = [(a.donationRequest.date.getTime()), (b.donationRequest.date.getTime())]; break;
        //case 'bloodType': [propertyA, propertyB] = [(a.donationData), (b.donationRequest.date)]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }

}

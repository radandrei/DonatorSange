import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { DataSource } from '@angular/cdk/collections';
import { MedicalRequest } from '../models/medicalrequest';
import { HttpClient } from '@angular/common/http';
import { RequestService } from '../services/request.service';

@Component({
  selector: 'app-medicalstaff-requests',
  templateUrl: './medicalstaff-requests.component.html',
  styleUrls: ['./medicalstaff-requests.component.css'],
  providers:[RequestService]
})
export class MedicalstaffRequestsComponent implements OnInit {

  displayedColumns = ['firstName', 'lastName', 'county','city','bloodComponentType','priority','quantity','status'];
  database: Database | null;
  dataSource: DataSourceMedicalRequest | null;
  selectedMedicalRequest: number;
  user = JSON.parse(localStorage.getItem('myUser'));
 

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;

  // constructor(http: HttpClient, private MedicalRequestService: MedicalRequestService, public dialog: MatDialog, private router:Router) {
  //   this.database = new Database(http, this.MedicalRequestService,router);
  // }


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
    this.dataSource = new DataSourceMedicalRequest(this.database, this.paginator, this.sort);
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
  user = JSON.parse(localStorage.getItem('myUser'));

  /** Adds a new MedicalRequest to the database. */
  addMedicalRequests(membersToAdd: Array<MedicalRequest>) {
    for (let i = 0; i < membersToAdd.length; i++) {
      const copiedData = this.data.slice();
      copiedData.push(membersToAdd[i]);
      this.dataChange.next(copiedData);
    }
  }

  /** Stream that emits whenever the data has been modified. */
  dataChange: BehaviorSubject<MedicalRequest[]> = new BehaviorSubject<MedicalRequest[]>([]);
  get data(): MedicalRequest[] { return this.dataChange.value; }

  constructor(private http: HttpClient, MedicalService: RequestService, private router:Router) {
    this.user = JSON.parse(localStorage.getItem('myMedicalRequest'));
    MedicalService.getAllMedicalRequests()
      .subscribe(
        MedicalRequests => { this.addMedicalRequests(MedicalRequests) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        }
      )
  };

  getMedicalRequest(id: number): MedicalRequest {
    const MedicalRequests: MedicalRequest[] = this.data;
    const length: number = MedicalRequests.length;
    let i;
    for (i = 0; i < length; i++) {
      if (MedicalRequests[i].id == id)
        return MedicalRequests[i]
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
export class DataSourceMedicalRequest extends DataSource<any> {
  _filterChange = new BehaviorSubject('');
  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }
  constructor(private _database: Database, private _paginator: MatPaginator, private _sort: MatSort) {
    super();
  }
  filterLength: number = this._database.data.length;

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<MedicalRequest[]> {
    const displayDataChanges = [
      this._database.dataChange,
      this._paginator.page,
      this._filterChange,
      this._sort.sortChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: MedicalRequest) => {
        let searchStr = "";
        return searchStr.indexOf(this.filter.toLowerCase()) != -1;
      });
      this.filterLength = elements.length;
      return this.getSortedData(elements).splice(startIndex, this._paginator.pageSize);
    });
  }

  getSortedData(elements: MedicalRequest[]): MedicalRequest[] {
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
        case 'bloodComponentType': [propertyA, propertyB] = [(a.bloodComponentType.name), (b.bloodComponentType.name)]; break;
        case 'priority': [propertyA, propertyB] = [(a.priority), (b.priority)]; break;
        case 'status': [propertyA, propertyB] = [(a.requestStatus.name), (b.requestStatus.name)]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }


}

import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { HttpClient } from 'selenium-webdriver/http';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { DataSource } from '@angular/cdk/collections';
import { RequestService } from '../services/request.service';

@Component({
  selector: 'app-medicalstaff-requests',
  templateUrl: './medicalstaff-requests.component.html',
  styleUrls: ['./medicalstaff-requests.component.css']
})
export class MedicalstaffRequestsComponent implements OnInit {

  isplayedColumns = ['firstName', 'lastName', 'county','city','phone','date'];
  database: Database | null;
  dataSource: DataSourceRequest | null;
  selectedRequest: number;
  user = JSON.parse(localStorage.getItem('myRequest'));
 

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;

  constructor(http: HttpClient, private RequestService: RequestService, public dialog: MatDialog, private router:Router) {
    this.database = new Database(http, this.RequestService,router);
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
    this.dataSource = new DataSourceRequest(this.database, this.paginator, this.sort);
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
  user = JSON.parse(localStorage.getItem('myRequest'));

  /** Adds a new Request to the database. */
  addRequests(membersToAdd: Array<Request>) {
    for (let i = 0; i < membersToAdd.length; i++) {
      const copiedData = this.data.slice();
      copiedData.push(membersToAdd[i]);
      this.dataChange.next(copiedData);
    }
  }

  /** Stream that emits whenever the data has been modified. */
  dataChange: BehaviorSubject<Request[]> = new BehaviorSubject<Request[]>([]);
  get data(): Request[] { return this.dataChange.value; }

  constructor(private http: HttpClient, RequestService: RequestService, private router:Router) {
    this.user = JSON.parse(localStorage.getItem('myRequest'));
    RequestService.getRequests(donationCenterId)
      .subscribe(
        Requests => { this.addRequests(Requests) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        }
      )
  };

  getRequest(id: number): Request {
    const Requests: Request[] = this.data;
    const length: number = Requests.length;
    let i;
    for (i = 0; i < length; i++) {
      if (Requests[i].id == id)
        return Requests[i]
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
export class DataSourceRequest extends DataSource<any> {
  _filterChange = new BehaviorSubject('');
  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }
  constructor(private _database: Database, private _paginator: MatPaginator, private _sort: MatSort) {
    super();
  }
  filterLength: number = this._database.data.length;

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Request[]> {
    const displayDataChanges = [
      this._database.dataChange,
      this._paginator.page,
      this._filterChange,
      this._sort.sortChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: Request) => {
        let searchStr = item.;
        return searchStr.indexOf(this.filter.toLowerCase()) != -1;
      });
      this.filterLength = elements.length;
      return this.getSortedData(elements).splice(startIndex, this._paginator.pageSize);
    });
  }

  getSortedData(elements: Request[]): Request[] {
    const data = elements.slice();
    if (!this._sort.active || this._sort.direction == '') { return data; }

    return data.sort((a, b) => {
      let propertyA: number | string | Date | boolean = '';
      let propertyB: number | string | Date | boolean = '';

      switch (this._sort.active) {
        case 'firstName': [propertyA, propertyB] = [(a.firstName), (b.firstName)]; break;
        case 'lastName': [propertyA, propertyB] = [(a.lastName), (b.lastName)]; break;
        case 'county': [propertyA, propertyB] = [(a.address.county), (b.address.county)]; break;
        case 'city': [propertyA, propertyB] = [(a.address.city), (b.address.city)]; break;
        case 'phone': [propertyA, propertyB] = [(a.phone), (b.phone)]; break;
        case 'date': [propertyA, propertyB] = [(a.request), (b.request)]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }


}

import { Component, OnInit } from '@angular/core';
import { products } from '../products';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products = products;
  
  constructor() { }

  ngOnInit(): void {
  }

}

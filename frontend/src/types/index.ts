export interface Product {
  id: string;
  name: string;
  description: string;
  price: number;
  stock: number;
}

export interface Customer {
  id: string;
  name: string;
  email: string;
  phone: string;
  address: string;
  createdAt: string;
}

export interface Sale {
  id: string;
  customerId: string;
  customerName: string;
  productId: string;
  productName: string;
  quantity: number;
  unitPrice: number;
  totalAmount: number;
  date: string;
}

export interface SaleRequest {
  customerId: string;
  productId: string;
  quantity: number;
}

export interface ApiResponse<T> {
  data: T;
  message?: string;
  success: boolean;
}
import type { Product, Customer, Sale, SaleRequest } from '../../types';


const mockProducts: Product[] = [
  {
    id: '1',
    name: 'Portátil Ultra',
    description: 'Ordenador portátil de alto rendimiento con SSD de 512 GB',
    price: 1299.99,
    stock: 25
  },
  {
    id: '2',
    name: 'Ratón Inalámbrico',
    description: 'Ratón ergonómico con sensor óptico de precisión',
    price: 49.99,
    stock: 150
  },
  {
    id: '3',
    name: 'Teclado Mecánico',
    description: 'Teclado mecánico con retroiluminación RGB',
    price: 129.99,
    stock: 75
  }
];

const mockCustomers: Customer[] = [
  {
    id: '1',
    name: 'Ana Pérez',
    email: 'ana.perez@ejemplo.com',
    phone: '+1 809-123-4567',
    address: 'Av. Duarte 123, Santo Domingo, RD',
    createdAt: '2024-01-15'
  },
  {
    id: '2',
    name: 'Carlos López',
    email: 'carlos.lopez@ejemplo.com',
    phone: '+1 809-234-5678',
    address: 'Calle Colón 456, Santiago, RD',
    createdAt: '2024-01-20'
  },
  {
    id: '1',
    name: 'Ana Pérez',
    email: 'ana.perez@ejemplo.com',
    phone: '+1 809-123-4567',
    address: 'Av. Duarte 123, Santo Domingo, RD',
    createdAt: '2024-01-15'
  },
  {
    id: '2',
    name: 'Carlos López',
    email: 'carlos.lopez@ejemplo.com',
    phone: '+1 809-234-5678',
    address: 'Calle Colón 456, Santiago, RD',
    createdAt: '2024-01-20'
  },
  {
    id: '1',
    name: 'Ana Pérez',
    email: 'ana.perez@ejemplo.com',
    phone: '+1 809-123-4567',
    address: 'Av. Duarte 123, Santo Domingo, RD',
    createdAt: '2024-01-15'
  },
  {
    id: '2',
    name: 'Carlos López',
    email: 'carlos.lopez@ejemplo.com',
    phone: '+1 809-234-5678',
    address: 'Calle Colón 456, Santiago, RD',
    createdAt: '2024-01-20'
  }
];

const mockSales: Sale[] = [
  {
    id: '1',
    customerId: '1',
    customerName: 'Ana Pérez',
    productId: '1',
    productName: 'Portátil Ultra',
    quantity: 1,
    unitPrice: 1299.99,
    totalAmount: 1299.99,
    date: '2024-01-25'
  },
  {
    id: '2',
    customerId: '2',
    customerName: 'Carlos López',
    productId: '2',
    productName: 'Ratón Inalámbrico',
    quantity: 2,
    unitPrice: 49.99,
    totalAmount: 99.98,
    date: '2024-01-24'
  },
  {
    id: '3',
    customerId: '1',
    customerName: 'Ana Pérez',
    productId: '3',
    productName: 'Teclado Mecánico',
    quantity: 1,
    unitPrice: 129.99,
    totalAmount: 129.99,
    date: '2024-01-23'
  }
];

// Simular retraso de API
const delay = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));

// API de Productos
export const productsApi = {
  getAll: async (): Promise<Product[]> => {
    await delay(500);
    return [...mockProducts];
  },

  create: async (product: Omit<Product, 'id'>): Promise<Product> => {
    await delay(300);
    const newProduct = { ...product, id: Date.now().toString() };
    mockProducts.push(newProduct);
    return newProduct;
  },

  update: async (id: string, product: Partial<Product>): Promise<Product> => {
    await delay(300);
    const index = mockProducts.findIndex(p => p.id === id);
    if (index !== -1) {
      mockProducts[index] = { ...mockProducts[index], ...product };
      return mockProducts[index];
    }
    return { ...product, id } as Product;
  },

  delete: async (id: string): Promise<void> => {
    await delay(300);
    const index = mockProducts.findIndex(p => p.id === id);
    if (index !== -1) mockProducts.splice(index, 1);
  }
};

// API de Clientes
export const customersApi = {
  getAll: async (): Promise<Customer[]> => {
    await delay(500);
    return [...mockCustomers];
  },

  create: async (customer: Omit<Customer, 'id' | 'createdAt'>): Promise<Customer> => {
    await delay(300);
    const newCustomer = {
      ...customer,
      id: Date.now().toString(),
      createdAt: new Date().toISOString().split('T')[0]
    };
    mockCustomers.push(newCustomer);
    return newCustomer;
  },

  update: async (id: string, customer: Partial<Customer>): Promise<Customer> => {
    await delay(300);
    const index = mockCustomers.findIndex(c => c.id === id);
    if (index !== -1) {
      mockCustomers[index] = { ...mockCustomers[index], ...customer };
      return mockCustomers[index];
    }
    return { ...customer, id } as Customer;
  },

  delete: async (id: string): Promise<void> => {
    await delay(300);
    const index = mockCustomers.findIndex(c => c.id === id);
    if (index !== -1) mockCustomers.splice(index, 1);
  }
};

// API de Ventas
export const salesApi = {
  getAll: async (): Promise<Sale[]> => {
    await delay(500);
    return [...mockSales];
  },

  create: async (sale: SaleRequest): Promise<Sale> => {
    await delay(300);
    const customer = mockCustomers.find(c => c.id === sale.customerId);
    const product = mockProducts.find(p => p.id === sale.productId);

    const newSale: Sale = {
      id: Date.now().toString(),
      ...sale,
      customerName: customer?.name ?? 'Cliente Desconocido',
      productName: product?.name ?? 'Producto Desconocido',
      unitPrice: product?.price ?? 0,
      totalAmount: sale.quantity * (product?.price ?? 0),
      date: new Date().toISOString().split('T')[0]
    };

    mockSales.push(newSale);
    return newSale;
  }
};
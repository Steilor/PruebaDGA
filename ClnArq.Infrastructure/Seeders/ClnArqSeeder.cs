
using ClnArq.Domain.Entities;
using ClnArq.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClnArq.Infrastructure.Seeders;

internal class ClnArqSeeder(ClnArqDbContext context) : IClnArqSeeder
{
    public async Task Seed()
    {
        await context.Database.MigrateAsync();

        if (await context.Productos.AnyAsync()) return;

        var productos = new[]
        {       new Producto { Id = Guid.Parse("A229CE62-6463-44D5-A3BA-079531506232"), Nombre = "Webcam Logitech", Descripcion = "Webcam Logitech de alta calidad", Precio = 469.38m, Stock = 51 },
                new Producto { Id = Guid.Parse("CAF1FFA5-CCE7-4A00-9FDB-1BED7044FF84"), Nombre = "SSD NVMe 500GB", Descripcion = "SSD NVMe 500GB de alta calidad", Precio = 135.12m, Stock = 146 },
                new Producto { Id = Guid.Parse("B10E5DA5-93F4-4BC7-B760-262AC95A175C"), Nombre = "Fuente de Poder EVGA", Descripcion = "Fuente de Poder EVGA de alta calidad", Precio = 419.73m, Stock = 68 },
                new Producto { Id = Guid.Parse("C89C62FA-CF56-4CF6-BD2E-29E644E9B4F8"), Nombre = "Audífonos Sony", Descripcion = "Audífonos Sony de alta calidad", Precio = 167.30m, Stock = 124 },
                new Producto { Id = Guid.Parse("44F61405-C986-4208-A159-3CE978ED111F"), Nombre = "TV LG 55\"", Descripcion = "TV LG 55\" de alta calidad", Precio = 138.80m, Stock = 80 },
                new Producto { Id = Guid.Parse("B3C2089C-32AD-4D0A-AB85-4144DD2FB48D"), Nombre = "iPhone 13", Descripcion = "iPhone 13 de alta calidad", Precio = 630.79m, Stock = 98 },
                new Producto { Id = Guid.Parse("3AC3DABA-09A7-4C86-9657-45E3958E74B1"), Nombre = "Escritorio Oficina", Descripcion = "Escritorio Oficina de alta calidad", Precio = 458.40m, Stock = 119 },
                new Producto { Id = Guid.Parse("64CD7320-EF7F-42E9-B4B3-4F3437ADBEBA"), Nombre = "Teclado Mecánico Redragon", Descripcion = "Teclado Mecánico Redragon de alta calidad", Precio = 764.45m, Stock = 83 },
                new Producto { Id = Guid.Parse("B8F254BA-911F-4807-8600-53BD006ECD51"), Nombre = "Memoria RAM 16GB", Descripcion = "Memoria RAM 16GB de alta calidad", Precio = 126.64m, Stock = 64 },
                new Producto { Id = Guid.Parse("A180A03A-32F6-4F0E-B3A0-6C0CFDCC0455"), Nombre = "Control Xbox", Descripcion = "Control Xbox de alta calidad", Precio = 83.52m, Stock = 84 },
                new Producto { Id = Guid.Parse("041F04B8-382E-4FC3-8B64-76F32C94E2AF"), Nombre = "Licuadora Oster", Descripcion = "Licuadora Oster de alta calidad", Precio = 91.96m, Stock = 124 },
                new Producto { Id = Guid.Parse("94EC8619-A9E0-46E3-A550-7829D53E688C"), Nombre = "Tablet Samsung Galaxy", Descripcion = "Tablet Samsung Galaxy de alta calidad", Precio = 750.25m, Stock = 120 },
                new Producto { Id = Guid.Parse("2F00203D-9ABF-48C9-8544-7BE4729A59B4"), Nombre = "Smartwatch Xiaomi", Descripcion = "Smartwatch Xiaomi de alta calidad", Precio = 884.09m, Stock = 101 },
                new Producto { Id = Guid.Parse("D6ED55ED-39BB-406B-B383-7FBFEDC1A5DD"), Nombre = "Disco Duro 1TB", Descripcion = "Disco Duro 1TB de alta calidad", Precio = 145.32m, Stock = 136 },
                new Producto { Id = Guid.Parse("17462B1B-060A-455F-A973-85DEF8817B69"), Nombre = "Mouse Logitech", Descripcion = "Mouse Logitech de alta calidad", Precio = 163.20m, Stock = 147 },
                new Producto { Id = Guid.Parse("574BBDAA-1086-4AF3-92BA-86427A378C8E"), Nombre = "Impresora Epson", Descripcion = "Impresora Epson de alta calidad", Precio = 860.45m, Stock = 68 },
                new Producto { Id = Guid.Parse("347BC97F-E464-433C-B6C9-914AE4B40325"), Nombre = "Cámara Canon EOS", Descripcion = "Cámara Canon EOS de alta calidad", Precio = 467.33m, Stock = 89 },
                new Producto { Id = Guid.Parse("0D5B92D1-238C-463B-8B8C-9681F50B88AF"), Nombre = "Case ATX Thermaltake", Descripcion = "Case ATX Thermaltake de alta calidad", Precio = 989.77m, Stock = 62 },
                new Producto { Id = Guid.Parse("20CBB5FF-B1F1-4FB3-8BD4-97FFC4AF5580"), Nombre = "Monitor Samsung 24\"", Descripcion = "Monitor Samsung 24\" de alta calidad", Precio = 357.44m, Stock = 102 },
                new Producto { Id = Guid.Parse("D8234A31-E607-4B75-A746-A57BF3B55B72"), Nombre = "Silla Gamer", Descripcion = "Silla Gamer de alta calidad", Precio = 259.16m, Stock = 50 },
                new Producto { Id = Guid.Parse("6DB6BFE8-1C9A-4F3B-A1C0-AB0D9E869BE6"), Nombre = "Bocinas JBL", Descripcion = "Bocinas JBL de alta calidad", Precio = 734.22m, Stock = 107 },
                new Producto { Id = Guid.Parse("E4E1853E-73CD-4CC6-96B9-AE68E7E3A20F"), Nombre = "Router TP-Link", Descripcion = "Router TP-Link de alta calidad", Precio = 37.24m, Stock = 122 },
                new Producto { Id = Guid.Parse("393A4607-CF53-44AB-8A05-B3B251CB7970"), Nombre = "Estufa Samsung", Descripcion = "Estufa Samsung de alta calidad", Precio = 528.90m, Stock = 90 },
                new Producto { Id = Guid.Parse("F9098B1B-7EEE-4609-A9BA-BBD85067FCFF"), Nombre = "Proyector Epson", Descripcion = "Proyector Epson de alta calidad", Precio = 605.42m, Stock = 97 },
                new Producto { Id = Guid.Parse("8196C894-F2EE-4626-8601-BDB3273EE195"), Nombre = "Repetidor WiFi", Descripcion = "Repetidor WiFi de alta calidad", Precio = 953.39m, Stock = 114 },
                new Producto { Id = Guid.Parse("B16E6468-A107-472A-8E9E-C684A06ACE6A"), Nombre = "Laptop Dell Inspiron", Descripcion = "Laptop Dell Inspiron de alta calidad", Precio = 1116.95m, Stock = 118 },
                new Producto { Id = Guid.Parse("6F28F15C-E954-40DF-84C2-E813C167E671"), Nombre = "Tarjeta Gráfica RTX 3060", Descripcion = "Tarjeta Gráfica RTX 3060 de alta calidad", Precio = 651.37m, Stock = 65 },
                new Producto { Id = Guid.Parse("FF7264BC-9AE5-4E92-8CCA-FAC44EFCB0BF"), Nombre = "Micrófono Blue Yeti", Descripcion = "Micrófono Blue Yeti de alta calidad", Precio = 906.01m, Stock = 132 },
                new Producto { Id = Guid.Parse("063CDB8D-1D92-4E2D-A2FE-FCDE5DC19F03"), Nombre = "Cargador Portátil", Descripcion = "Cargador Portátil de alta calidad", Precio = 667.06m, Stock = 124 },
                new Producto { Id = Guid.Parse("CBA0E0F4-F4E1-4A08-B4E4-FE3C6E57646E"), Nombre = "Cafetera Philips", Descripcion = "Cafetera Philips de alta calidad", Precio = 544.15m, Stock = 145 }
            };
        await context.Productos.AddRangeAsync(productos);

        var clientes = new[]
        {
            new Cliente { Id = Guid.Parse("4F159D3E-8C27-4A5D-9B64-0C371F3AE8C3"), Nombre = "María Gómez",       Email = "maria@mail.com",    Telefono = "809-513-2847", Direccion = "Calle 15 #482" },
            new Cliente { Id = Guid.Parse("9A1B2C3D-4E5F-6A7B-8C9D-0E1F2A3B4C5D"), Nombre = "Lorena Méndez",    Email = "lorena@mail.com",   Telefono = "809-937-6154", Direccion = "Calle 54 #751" },
            new Cliente { Id = Guid.Parse("2A1B3C4D-5E6F-7A8B-9C0D-1E2F3A4B5C6D"), Nombre = "Sergio Acosta",    Email = "sergio@mail.com",   Telefono = "809-712-8394", Direccion = "Calle 14 #617" },
            new Cliente { Id = Guid.Parse("1A2B3C4D-5E6F-7A8B-9C0D-1E2F3A4B5C6D"), Nombre = "Diego Peña",       Email = "diego@mail.com",    Telefono = "809-319-8472", Direccion = "Calle 82 #583" },
            new Cliente { Id = Guid.Parse("9B1E5AD3-02C4-483B-A3D1-1F7DF1B89F4A"), Nombre = "Miguel Torres",    Email = "miguel@mail.com",   Telefono = "809-535-7291", Direccion = "Calle 8 #503" },
            new Cliente { Id = Guid.Parse("6D4F5B2C-7B3D-42D5-A1E8-2E4B7C8A5D2F"), Nombre = "Eduardo Soto",     Email = "eduardo@mail.com",  Telefono = "809-798-5426", Direccion = "Calle 77 #609" },
            new Cliente { Id = Guid.Parse("5C4D3B2A-1E7F-4A9B-8C6D-2E5F9A0B1C2D"), Nombre = "Iván Castillo",     Email = "ivan@mail.com",     Telefono = "809-318-4725", Direccion = "Calle 45 #629" },
            new Cliente { Id = Guid.Parse("2B3C4D5E-6F7A-8B9C-0D1E-2F3A4B5C6D7E"), Nombre = "Alejandra Barrios", Email = "alejandra@mail.com", Telefono = "809-547-1836", Direccion = "Calle 63 #186" },
            new Cliente { Id = Guid.Parse("6A63AD3F-5BA8-474D-92B9-374CFD96F552"), Nombre = "José Fernández",   Email = "jose@mail.com",     Telefono = "809-964-5320", Direccion = "Calle 21 #295" },
            new Cliente { Id = Guid.Parse("3D2C1B0A-9E8F-7D6C-5B4A-3E2F1D0C9B8A"), Nombre = "Raúl Romero",      Email = "raul@mail.com",     Telefono = "809-682-1947", Direccion = "Calle 27 #804" },
            new Cliente { Id = Guid.Parse("2D73E4A6-7E4C-45F9-9C1C-3E982C2F5DED"), Nombre = "Antonio Ruiz",    Email = "antonio@mail.com",  Telefono = "809-453-1182", Direccion = "Calle 50 #270" },
            new Cliente { Id = Guid.Parse("4C5D6E7F-8A9B-0C1D-2E3F-4A5B6C7D8E9F"), Nombre = "Paola Duarte",     Email = "paola@mail.com",    Telefono = "809-236-5478", Direccion = "Calle 39 #248" },
            new Cliente { Id = Guid.Parse("2F1E3D4B-8C2A-4E6F-B4D9-5A8C7E9D0B3F"), Nombre = "Verónica Rivas",   Email = "veronica@mail.com", Telefono = "809-399-2715", Direccion = "Calle 18 #374" },
            new Cliente { Id = Guid.Parse("B2E4F5D6-3A7B-4C8E-9D2F-5A8C7E9D1B2C"), Nombre = "Gabriela León",    Email = "gabriela@mail.com", Telefono = "809-542-8173", Direccion = "Calle 31 #472" },
            new Cliente { Id = Guid.Parse("A282F51A-2219-4F9F-A06D-691B869BEAD8"), Nombre = "Laura Martínez",   Email = "laura@mail.com",    Telefono = "809-859-4366", Direccion = "Calle 69 #749" },
            new Cliente { Id = Guid.Parse("3A1C8B2E-6F2B-4B3F-99BC-6C3AE6D8E8F1"), Nombre = "Isabel Ortega",    Email = "isabel@mail.com",   Telefono = "809-674-3125", Direccion = "Calle 19 #147" },
            new Cliente { Id = Guid.Parse("C5BE4A91-3D8E-41A1-9D3F-6D7BBF2F8A5E"), Nombre = "Pedro Sánchez",    Email = "pedro@mail.com",    Telefono = "809-918-2763", Direccion = "Calle 4 #994" },
            new Cliente { Id = Guid.Parse("4E6D7C8A-5B4E-4F1D-9C3A-7E2F9D0B1C3A"), Nombre = "Daniela Muñoz",    Email = "daniela@mail.com",  Telefono = "809-715-8269", Direccion = "Calle 27 #519" },
            new Cliente { Id = Guid.Parse("8F7E6D5C-4B3A-2C1D-0E9F-8A7B6C5D4E3F"), Nombre = "Natalia Paredes",  Email = "natalia@mail.com",  Telefono = "809-491-7362", Direccion= "Calle 61 #392" },
            new Cliente { Id = Guid.Parse("8AE7CF50-9E1B-4F02-ADE2-8AFFC6D9B4D2"), Nombre = "Lucía Herrera",    Email = "lucia@mail.com",    Telefono = "809-642-5018", Direccion = "Calle 12 #217" },
            new Cliente { Id = Guid.Parse("E2A45F36-5B2C-4F9C-A6D2-8F3E5B7C9D8A"), Nombre = "Andrés Silva",     Email = "andres@mail.com",   Telefono = "809-472-9836", Direccion = "Calle 72 #215" },
            new Cliente { Id = Guid.Parse("E6C99490-AACB-4BC7-9CD2-9918CCFCCA71"), Nombre = "Jorge Castro",     Email = "jorge@mail.com",    Telefono = "809-314-9826", Direccion = "Calle 22 #463" },
            new Cliente { Id = Guid.Parse("FD7B5A81-2FC1-4ACB-8D1E-9B6C7BDDF1E4"), Nombre = "Patricia Morales", Email = "patricia@mail.com", Telefono = "809-225-6493", Direccion = "Calle 58 #732" },
            new Cliente { Id = Guid.Parse("13CC4DDA-0275-49C3-B4ED-B3A0845117B6"), Nombre = "Fernando Delgado",  Email = "fernando@mail.com", Telefono = "809-797-2164", Direccion = "Calle 33 #196" },
            new Cliente { Id = Guid.Parse("B4A95074-9F09-4D2C-A937-B729E1387611"), Nombre = "Carmen Díaz",      Email = "carmen@mail.com",   Telefono = "809-881-6349", Direccion = "Calle 65 #859" },
            new Cliente { Id = Guid.Parse("A6381951-82B4-4A1B-8A03-C3BFBB642243"), Nombre = "Rosa Vargas",      Email = "rosa@mail.com",     Telefono = "809-613-4928", Direccion = "Calle 40 #821" },
            new Cliente { Id = Guid.Parse("EEA1A7B2-9DC1-4E8F-8A12-D8A3F5A2795E"), Nombre = "Luis Pérez",       Email = "luis@mail.com",     Telefono = "809-411-7623", Direccion = "Calle 39 #318" },
            new Cliente { Id = Guid.Parse("F73DA4BC-E7B1-4F3E-B2D2-EBC4B8A22819"), Nombre = "Ana Rodríguez",    Email = "ana@mail.com",      Telefono = "809-724-1983", Direccion = "Calle 82 #101" },
            new Cliente { Id = Guid.Parse("3EC6DFA6-5FC6-486D-BDEE-F3F626A98865"), Nombre = "Carlos Ramírez",   Email = "carlos@mail.com",   Telefono = "809-728-9991", Direccion = "Calle 27 #725" }
        };
        await context.Clientes.AddRangeAsync(clientes);

        await context.SaveChangesAsync();

      
        var rnd = new Random();
        var prods = await context.Productos.ToListAsync();
        var clis = await context.Clientes.ToListAsync();

        for (int i = 0; i < 40; i++)
        {
            var prod = prods[rnd.Next(prods.Count)];
            var cli = clis[rnd.Next(clis.Count)];
            int qty = rnd.Next(1, 6); 
            decimal unitPrice = prod.Precio;
            decimal total = unitPrice * qty;
            var fecha = DateTime.UtcNow.AddDays(-rnd.Next(0, 30));

            var venta = new Venta
            {
                Fecha = fecha,
                Cantidad = qty,
                Total = total,
                ClienteId = cli.Id,
                ProductoId = prod.Id,
                ClienteNombre = cli.Nombre,
                ProductoNombre = prod.Nombre,
                ProductoPrecioUnitario = unitPrice
            };
            await context.Ventas.AddAsync(venta);
            await context.SaveChangesAsync(); 

       
            var detalle = new DetalleVenta
            {
                VentaId = venta.Id,
                ProductoId = prod.Id,
                Cantidad = qty,
                PrecioUnitario = unitPrice
            };
            await context.DetallesVenta.AddAsync(detalle);
        }

        await context.SaveChangesAsync();
    }
}

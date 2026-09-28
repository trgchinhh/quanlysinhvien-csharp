// Console
// Chương trình nhỏ quản lý sinh viên với các chức năng cơ bản 
// Mục đích: làm quen OOP và cú pháp C#

using Spectre.Console;

public class Program {
    public static string noidungbanner = @"┌──────────────────────────────┐
│     QUẢN LÝ SINH VIÊN C#     │
│ Tác giả: Trường Chinh        │
│ Github: Github.com/trgchinhh │
└──────────────────────────────┘
        ";
    public static void dungchuongtrinh(){
        Console.Write("\nNhấn phím bất kỳ để tiếp tục ...");
        Console.ReadKey();
    }

    public static Color chonmau(){
        Console.Clear();
        Console.WriteLine(noidungbanner);

        // phần hướng dẫn dùng 
        AnsiConsole.Write(
            new Panel(
                "Dùng phím ↑ ↓ để di chuyển\n" +
                "Dùng phím Enter để chọn"
            )
            .Header("Hướng dẫn")
        );

        Console.WriteLine("\nChọn màu menu");
        var luachonmau = AnsiConsole.Prompt(
            new SelectionPrompt<int>()
            .AddChoices(1, 2, 3, 4, 5, 6, 7, 8)
            .WrapAround(true)
            .HighlightStyle(new Style(Mau.danhsachmau[6]))
            .UseConverter(x => x switch {
                1 => Markup.Escape("[01] Màu đỏ"),
                2 => Markup.Escape("[02] Màu xanh lá"),
                3 => Markup.Escape("[03] Màu vàng"),
                4 => Markup.Escape("[04] Màu cam"),
                5 => Markup.Escape("[05] Màu xanh ngọc"),
                6 => Markup.Escape("[06] Màu xanh cyan"),
                7 => Markup.Escape("[07] Màu mặc định"),
                8 => Markup.Escape("[08] Thoát"),
                _ => ""
            })
        );
        if(luachonmau == 8) Environment.Exit(0);
        return Mau.danhsachmau[luachonmau - 1];
    }

    public static void Main(){
        QuanLySinhVien quanlysinhvien = new QuanLySinhVien();
        quanlysinhvien.napdulieudanhsach();
        
        var luachonmau = chonmau();

        int luachontruoc = 0;
        while(true){
            Console.Clear();
            Console.WriteLine(noidungbanner);

            Console.WriteLine("  MENU");
            var luachon = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                .AddChoices(0, 1, 2, 3, 4, 5, 6, 7)
                .WrapAround(true)
                .HighlightStyle(new Style(luachonmau))
                .DefaultValue(luachontruoc)
                .UseConverter(x => x switch {
                    0 => Markup.Escape("[00] Thay màu"),
                    1 => Markup.Escape("[01] Xem danh sách"),
                    2 => Markup.Escape("[02] Thêm sinh viên"),
                    3 => Markup.Escape("[03] Sửa thông tin"),
                    4 => Markup.Escape("[04] Sắp xếp thông tin"),
                    5 => Markup.Escape("[05] Xóa thông tin"),
                    6 => Markup.Escape("[06] Thống kê"),
                    7 => Markup.Escape("[07] Thoát"),
                    _ => ""
                })
            );
            luachontruoc = luachon;
            Console.WriteLine();
            if(luachon == 0){
                luachonmau = chonmau();
                continue;
            }
            else if(luachon == 1){
                quanlysinhvien.XuatDanhSach();
            }
            else if(luachon == 2){
                quanlysinhvien.ThemThongTinSinhVien();
            }
            else if(luachon == 3){
                quanlysinhvien.SuaThongTinSinhVien();
            }
            else if(luachon == 4){
                quanlysinhvien.SapXepThongTinSinhVien();
            }
            else if(luachon == 5){
                quanlysinhvien.XoaThongTinSinhVien();
            }
            else if(luachon == 6){
                quanlysinhvien.ThongKeThongTinSinhVien();
            }
            else if(luachon == 7){
                Console.WriteLine("Hẹn gặp lại !");
                break;
            } 
            else {
                Console.WriteLine("Vui lòng chọn đúng !");
            }
            dungchuongtrinh();
        }
    }
}
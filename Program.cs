using System.Text;

public class Program {
    public static void banner(){
        Console.WriteLine(@"
  ____  _    _         _   _   _  __     __   _____ _____ _   _ _    _  __      _______ ______ _   _ 
 / __ \| |  | |  /\   | \ | | | | \ \   / /  / ____|_   _| \ | | |  | | \ \    / /_   _|  ____| \ | |
| |  | | |  | | /  \  |  \| | | |  \ \_/ /  | (___   | | |  \| | |__| |  \ \  / /  | | | |__  |  \| |
| |  | | |  | |/ /\ \ | . ` | | |   \   /    \___ \  | | | . ` |  __  |   \ \/ /   | | |  __| | . ` |
| |__| | |__| / ____ \| |\  | | |____| |     ____) |_| |_| |\  | |  | |    \  /   _| |_| |____| |\  |
 \___\_\\____/_/    \_\_| \_| |______|_|    |_____/|_____|_| \_|_|  |_|     \/   |_____|______|_| \_|                                                                                            
        ");
    }

    public static void dungchuongtrinh(){
        Console.Write("\nNhấn enter để tiếp tục...");
        Console.ReadKey();
    }

    public static void taodulieusinhvien(QuanLySinhVien quanlysinhvien){
        // tạo db sẵn nếu chưa có file hoặc file ko có data
        if(System.IO.File.Exists("danhsach.txt")){
            quanlysinhvien.docfilevaobandau();
        } else {
            quanlysinhvien.themsinhvien(new SinhVien("Chinh", "001", 9.5f));
            quanlysinhvien.themsinhvien(new SinhVien("Phúc", "002", 8.5f));
            quanlysinhvien.themsinhvien(new SinhVien("Bảo", "003", 8.0f));
        }
    }

    public static void Main(){
        Console.OutputEncoding = Encoding.UTF8;
        QuanLySinhVien quanlysinhvien = new QuanLySinhVien();
        taodulieusinhvien(quanlysinhvien);

        // in lần đầu cho đánh stt
        quanlysinhvien.inthongtinsinhvien();

        while(true){
            taodulieusinhvien(quanlysinhvien);
            Console.Clear();
            banner();
            quanlysinhvien.hienthithucdon();
            Console.Write("[?] Lựa chọn: ");
            if(!int.TryParse(Console.ReadLine(), out int luachon)){
                Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập số");
                continue;
            }

            Console.WriteLine("");
            if(luachon == 0){
                Console.WriteLine("Hẹn gặp lại !");
                break;
            } 
            else if(luachon == 1){
                quanlysinhvien.inthongtinsinhvien();
            }
            else if(luachon == 2){
                quanlysinhvien.themsinhvien(quanlysinhvien.nhapthongtinsinhvien());
            }
            else if(luachon == 3){
                quanlysinhvien.inthongtinsinhvien();
                Console.Write("Nhập STT sinh viên cần sửa: ");
                if(int.TryParse(Console.ReadLine(), out int sttsua)){
                    quanlysinhvien.suathongtinsinhvien(sttsua);
                }
            }
            else if(luachon == 4){
                quanlysinhvien.inthongtinsinhvien();
                Console.Write("Nhập STT sinh viên cần xóa: ");
                if(int.TryParse(Console.ReadLine(), out int sttxoa)){
                    quanlysinhvien.xoasinhvien(sttxoa);
                }
            }
            else if(luachon == 5){
                quanlysinhvien.sapxepsinhvien();
            }
            else if(luachon == 6){
                quanlysinhvien.thongkesinhvien();
            }
            else {
                Console.WriteLine("Lựa chọn không hợp lệ");
            }
            dungchuongtrinh();
        }
    }
}

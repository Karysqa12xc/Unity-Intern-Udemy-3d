* Section 1: Introduction and Setup
	* Nội dung:
	* Giới thiệu về khoá học và cách setup môi trường code với Unity/VSCode
	Prefabs là gì 
	* Viết Script đầu tiên
	Giới thiệu về cộng đồng và cách tìm các đường dẫn để fix
	
* Section 2: Làm game Obstacle
	* Design của game: Camera di chuyển theo Player, Player phải tránh vật thể và đi từ điểm A sang
	điểm B
	* Start(): Hàm dùng để khởi tạo các giá trị chỉ chạy duy nhất một lần khi khởi động trò chơi
	* Update(): Hàm lặp chạy nhiều lân dựa trên số khung hình mà máy tính có thể đưa ra
	* Variables: Giúp lưu trữ dữ liệu(giống như một chiếc hộp đựng đồ bên trong) với kiểu dữ liệu
	và tên biến
	* SerializeField: Hiển thị các biến có access modifier là private or protected lên màn hình Inspector
	* Sử dụng Ctrl + Shift + F: để format code, sử dụng Input.GetAxis() để nhận các sự kiện nút
	bấm của tổ hợp phím mũi tên và wasd
	* Time.deltaTime: Có tác dụng làm mượt khung hình sao cho mỗi một giây sẽ chỉ có một khung hình được 
	sinh ra bất kể máy mạnh hay yếu. Ví dụ một máy có thể sinh ra 30 frame/s thì sẽ được tính như
	sau: 1 * 30 * 1/30 = 1
	* Cinemachine Camera: Di chuyển camera như một máy ảnh điện ảnh
	* Basic Collision: Tạo va trạm trong unity(Để có thể nhận hiện tượng va trạm thì cần có Rigidbody
	để tái tạo vật lý
	* Methods: Sử dụng để chia code theo từng chức năng cụ thể
	* OnCollisionEnter(): Sử dụng khi va chạm vào vật thể trong môi trường 3D
	GetComponent<>(): dùng để lấy các component của vật thể
	* Sử dụng Time.time để đếm thời gian trong trò chơi
	* Sử dụng tag để nhận diện các nhóm object 
* Section 3: Project Boost
	* Design của game: Điều khiển tàu vũ trụ tránh các vật thể và đi dến đích, khi đến đích sẽ hoàn
	thành một cấp độ và tiến sang cấp độ tiếp theo
	* Onion Design: Xác định các tính năng quan trọng của hệ thống game rồi sắp xếp nó theo thứ tự
	ưu tiên thành từng vòng tròn với vòng tròn trung tâm là quan trọng nhất rồi tăng dần mức
	độ => Đối với game boost thì theo thứ tự của Onion Design là: Movement/Flying, 
	World collision, Level progression
	* Input Binding: GetKet(), GetKeyDown(), GetKeyUp();
	* Dùng SceneManager.GetActiveScene().buildIndex để tại lại cảnh hiện tại đang được Active
	* Dùng SceneManager.sceneCountInBuildSettings để đếm số lượng Scene đang tồn tại trong build
	* Invoke(): Phương thực dùng để gọi một hàm với khoảng thời gian delay
	* Audio.PlayOneShot(): Phương thức này có thể chỉ định nhiều nguồn âm thanh và âm lượng của
	âm thanh đó
	* Particle System: Dùng để tạo effects
	* Point Light một kiểu light làm sáng theo các góc
	* Movement Factor: Di chuyển vật thể từ vị trí hiện tại của vật thể đến một vị trí chỉ định rồi
	từ vị trí đó di chuyển người lại vị trí ban đầu
	Dùng Application.Quit(): để thoát ứng dụng


	
	
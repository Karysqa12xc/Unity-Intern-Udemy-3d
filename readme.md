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
* Section 4: Argom Assault
	* Game design: Player di chuyển spaceship theo chiều ngang và dọc, spaceship sẽ có chức năng bắn
	đạn. Camera di chuyển theo rail/path. Các enemies có thể bắn đạn để tấn công người chơi, 
	Enemy di chuyển hoặc đứng yên. Mỗi khi tiêu diệt Enemy người chơi sẽ được cộng điểm. Khi người
	chơi bị tiêu diệt thì sẽ quay trở lại điểm bắt đầu và lấy số điểm ao nhất của người hơi
	* Terrain: 
		* Plain Terrain: 
			* Raise of lower terrain tạo vùng địa hình 
			* Set height: Sử dụng chủ yếu để xoá địa hình
	* Package Terrain Tool bao gồm những chức năng
		* Sculpt/Bright: Tạo cầu(chỉ định điểm A bằng cách giữ nút ctrl và click chuột vào 
		một điểm khác để tạo cầu. Lưu ý địa hình phải không bằng phẳng
		* Sculpt/Clone: Tạo bản sao của một địa hình khác
		* Erosion/Wind: Mô phỏng gió thổi qua địa hình 
		* Smooth Terrain: Làm mịn địa hình
		* Transform/Pinch: Chỉnh sửa vùng địa hình theo chiều hướng lên
		* Transform/Smudge: Chỉnh sửa vùng địa hình theo chiều hướng xuống
		* Transform/Twist: Chỉnh sửa vùng địa hình theo vòng xoắn
		* Paint Holes: Tạo khoảng chống giữa các vùng địa hình
		* Sử dụng A: để tăng strength của brush
		* Sử dụng D: để thay đổi góc xoay của brush 
		* Sử dụng S: đê thay đổi size của brush
	* Sử dụng Asset Store để tải các tài nguyên có sẵn
	* Texturing Terrain
		* Bump Map: Kết cấu về thông tin của ánh sáng bắt môt hình dạng mà có thể làm cho 
		bản đồ 2D giống với bản đồ 3D
		Height Map: hình ảnh hiển thị dưới dạng trắng đen dùng để mô tả chiều cao của 
		địa hình
		* Normal map: Sử dụng hệ màu RGB để hiện thị hướng của ánh sáng được khắc hoạ(độ phủ
		bóng của địa hình) 
	* Thêm Trees vào Terrain
	* Sử dụng Timeline để điều khiển nhiều Animation
	* Align with view: Lựa chọn vị trí và góc xoay của scene cho camera
	Sử dụng Curves trong Timeline để chỉnh góc xoay, toạ độ dễ dàng hơn
	* Sử dụng Input System để tạo khả năng điều khiển cho nhiều hệ máy
	* Mathf.Clamp(): Giới hạn vùng di chuyển của vật thể trong scene
	* Header Attribute: dùng để nhóm các thuộc tính
	* Tooltip Attribute: Dùng để mô tả thuộc tính khi blur vào thuộc tính trong cửa sổ inspector
	* Collision cho ParticleSystem: Sử dụng hàm OnParticleCollision() để làm tạo va chạm cho ParticleSystem(lưu 
	ý khi dùng phải bật Send Collision Messages)
	* Sử dụng GameObject.FindWithTag(): để tìm GameObject theo tag
	* Sử dụng Control Back để gom cụm animation để thành một đoạn để lồng vào đoạn khác
	* Singleton Pattern: Tạo một đối tượng duy nhất trong game tồn tại ở tất cả các scene, thường được dùng để quản lý âm
	thanh
	* SkyBox/6 slice: gộp các texture lại với nhau để tạo skybox
		* Exposure: tạo độ sáng
		* Rotation: Xoay Skybox
	* Lighting => Enviroment => Other Settings => Fog: để tạo sương mù cho trò chơi
	* Post-Processing: Thêm hiệu ứng cho camera để thay đổi góc nhìn trong Game(gồm Process Profile, Process Layer, Process Volume)
* Section 5: Realm Rush
	* Game Design: Kiểu game thủ thành người chơi có thể đặt các các cấu trúc phòng thủ và tiêu diệt các enemies trong các lượt
	tấn công.
	* Sử dụng Attribute ExecuteAlways để script luôn chạy ở chế độ Editor và chế độ Play
	* InvokeRepeating(): Dùng để lặp lại một hàm với thời gian nhất định trong đó có 3 tham số là chuỗi tên hàm, thời gian trễ khi
	lặp, thời gian lặp lại
	* Prefab Variant: là một biến thể được xác định của các prefabs có sẵn giúp thay đổi các biến thể từ bản gốc. Ví dụ 
	ta có một prefabs màu đỏ khi ta tạo Prefab Variant thì ta có thể sửa đổi và thay đổi prefabs đó mà không ảnh hưởng đến
	bản gốc và ngược lại nếu ta thay đổi ở bản gốc thì các bản sao cũng sẽ được thay đổi theo
	* Vector3.Lerp: Đi từ điểm A đến điểm B với tốc độ tăng dần
	* WaitForEndOfFrame(): Thời gian đợi cho khung được kết thúc
	Trong Particle System: tắt shape để tất cả các vật chỉ được render ra một đường thẳng
	* ObjectPool: Quản lý việc sinh ra đối tượng mà có thể tận dụng lại những đối tượng đã dùng, đối tượng đã dùng xong sẽ được
	ẩn đi chứ không bị Destroy tránh làm lãng phí tài nguyên.
	* Xây dựng hệ thống tiền tệ: Tạo một lớp Bank để quán lý tiền => Lớp Enemy liên kết với Bank và gọi lại các hàm của Bank, 
	check Eneny Die thì cộng tiền
	* Sử dụng Text Mesh Pro để tạo được kiểu chữ đẹp hơn sơ với TextMesh thông thường vì TextMesh Classic được tạo bằng các Bitmap 
	nên khi phóng to sẽ bị mờ.
	* Search Algorithms Overview:
		* Breadth First Search: Luôn trả về đường đi ngắn nhất, có thể có nhiều điểm đầu và điểm đích, 
		tốc độ ở mức trung binh
			* Duyệt các node trong đường đi theo các chiều khác nhau(lên, xuống, trái, phải) để tìm đường đi
		* Dijkstra: Luôn trả về đường đi ngắn nhất, Tiết kiệm chi phí di chuyển,có thể có nhiều điểm đầu và điểm dích, 
		tốc độ thuật toán ở mức chậm
		* A*: Có lúc trả về đường đi ngắn nhất có lúc không, Tiết kiệm chi phí di chuyển, có thể có nhiều điểm đầu và điểm 
		đích, tốc độ thuật toán ở mức nhanh(nhưng trong trường hợp xấu nhất thuật toán này cũng có tốc độ ngang với
		thuật toán Dijkstra). thuật toán này áp dụng Heuristics để liên tục cái tiến đường đi lên người dùng không 
		thể dự đoạn được số bước nó cần lặp lại để tìm đường
	* Sử dụng System.Serializable Attribute để hiển thị Class thuần trong Inspector 
	* Dictionary: 
		* Kiểu cấu trúc dữ liệu lưu theo dạng cặp key-values
		* Mỗi Keys sẽ quản lý một Values riêng
		* Keys phải là duy nhất(không được trùng nhau) và phải thật đơn giản
		* Values có thể là nhiều kiểu dữ liệu
		* Values có thể null
		* Keys không được null
		* Việc truy xuất từ Keys đến
		* Values là rất nhanh ngược lại thì rất chậm
	* BroadcastMessage: Chuyền một tên hàm vào điều này giúp cho hàm BroadcastMessage này thực hiện chức năng gọi tất cả các 
	method có tên được truyền vào BroadcastMessage trong các class kế thức MonoBehavior
	* Vào Project Settings -> Script
	* Execution Order: để sắp xếp tập lệnh


	
	
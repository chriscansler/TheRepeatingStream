RecentNumbers rn = new RecentNumbers();

Thread thread = new Thread(rn.Run);
thread.Start();

while(true){
    Console.ReadKey();
    if (rn.Recent1 == rn.Recent2) Console.WriteLine("A match!");
    else Console.WriteLine("Not a match.");
}

class RecentNumbers {
    private readonly object _numberLock = new object();
    private int _recent1;
    private int _recent2;

    public int Recent1 {
        get {
            lock (_numberLock) {
                return _recent1;
            }
        }

        set {
            lock (_numberLock) {
                _recent1 = value;
            }
        } 
    }
    public int Recent2 {
        get {
            lock (_numberLock) {
                return _recent2;
            }
        }

        set {
            lock (_numberLock) {
                _recent2 = value;
            }
        } 
    }    

    public RecentNumbers() { 
        _recent1 = -1;
        _recent2 = -1; 
    }

    public void Run() {
        Random random = new Random();
        int x = 0;
        while(true) {
            x = Convert.ToInt32(random.Next(10));    
            Recent2 = Recent1;
            Recent1 = x;
            // Console.WriteLine($"Recent1: {Recent1} Recent2: {Recent2}");
            Thread.Sleep(1000);
        }
    }
}

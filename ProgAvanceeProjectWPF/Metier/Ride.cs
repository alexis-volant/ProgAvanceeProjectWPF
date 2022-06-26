class Ride
{
    private int num;
    private string placeDeparture;
    private string dateDeparture;
    private double packageFee;
    private Category category;

    public Ride(int num, string placeDeparture, string dateDeparture, double packageFee, Category category)
    {
        this.num = num;
        this.placeDeparture = placeDeparture;
        this.dateDeparture = dateDeparture;
        this.packageFee = packageFee;
        this.category = category;
    }

    public int Num
    {
        get { return num; }
        set { num = value; }
    }

    public string PlaceDeparture
    {
        get { return placeDeparture; }
        set { placeDeparture = value; }
    }

    public string DateDeparture
    {
        get { return dateDeparture; }
        set { dateDeparture = value; }
    }

    public double PackageFee
    {
        get { return packageFee; }
        set { packageFee = value; }
    }

    public Category Category
    {
        get { return category; }
        set { category = value; }
    }

    public void addParticipant()
    {

    }

    public void getTotalMemberPlaces()
    {

    }

    public void getRestMemberPlaces()
    {

    }

    public void getTotalBikePlaces()
    {

    }

    public void getRestBikePlaces()
    {

    }

    public void getMemberPlacesNeed()
    {

    }

    public void getBikePlacesNeed()
    {

    }

    public void addVehicle()
    {

    }
}

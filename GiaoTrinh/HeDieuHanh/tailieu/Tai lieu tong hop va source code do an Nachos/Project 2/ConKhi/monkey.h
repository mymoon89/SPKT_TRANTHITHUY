#ifndef MONKEY_H
#define MONKEY_H
class Monkey 
{
private:
        static int mCount;
        int stt; //so thu tu cua con khi
        char *depart;
public:
        Monkey(char *place); //khoi tao con khi den tu place
        ~Monkey();
        //void SetNumber(int num) {  = num; };
        //int GetNumber() { return number; };
        void Cross(char *place); // con khi den tu place qua cau
        void Arrive(); //con khi vao hang doi de qua cau
};

int Monkey::mCount = 0;
Monkey::Monkey(char *place)
{
        depart = new char[5];
        strcpy(depart, place);
       // numMonkeys++;
        mCount++;
        stt = mCount;
}
Monkey::~Monkey()
{
        delete depart;
}

void Monkey::Cross(char *place)
{
       // int id;
       // char dest[5];
       // id = Open(filename, ROFILE);
       // Read(dest, 5, id);
        if( strcmp(depart, place) == 0 ) //neu depart = place
                                         //thi duoc uu tien qua cau
        {
                printf("Con thu %d dang tu huong %s", stt, place);
        }
}
#endif

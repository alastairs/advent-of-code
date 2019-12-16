using Xunit;

namespace OrbitMap.Tests
{
    public class AcceptanceTests
    {
        private const string MapDescriptor = @"YP6)HRL
5SN)Z3H
46K)CGP
PW2)SB6
NMH)673
36N)VHW
692)P3K
JCZ)ZM5
QMQ)KTT
NCT)K3G
YYB)155
MGN)272
MCC)6P8
3FT)X4C
YFC)1DL
5XK)839
VHJ)M9V
76Q)VRX
CGP)P3D
7Z5)GLK
C7X)LR1
F1Z)XK6
H94)VP6
5R9)C26
XLY)6B3
MQX)PYZ
SK4)6HK
WQV)PNN
Z7V)ZGZ
8YM)1QG
YR8)P91
B4V)52L
JRN)LRN
QWH)1GN
D8Y)H64
LWM)R33
C6G)CJD
7HK)D7M
TBX)JFZ
QG2)1BM
XP8)4C7
2WD)2PL
MHG)2SW
3YY)3CZ
8W4)DPV
9Q5)44R
5GW)339
KZB)H2P
WWP)RGG
D6P)PBJ
7MC)46Z
9RJ)T32
JQ7)MZ8
5NC)65D
TC2)VFB
7TX)Z7V
JCH)V88
C4F)FYX
G4C)CTM
47X)RT5
7T1)H9H
BQM)38T
YR9)XTY
DJJ)N1Y
8XB)QHN
GCG)6FJ
CT2)THZ
15G)BH2
Y18)JDT
TCS)X8T
YTM)KFT
QDT)665
HNM)RM8
SWQ)5GK
KKG)5JZ
RNZ)RZV
F9G)JF3
H5Y)1G6
F2P)DMS
F5S)H5G
1WH)XT3
RD6)522
1GS)9DD
N33)9RM
42H)P3F
2GS)28S
T9X)JPH
1VS)76Q
3RR)Q5R
6N7)J51
W2G)ZTN
FL4)84Q
W38)VXQ
F9G)ZFJ
MV4)R4R
Y7N)XXD
4Y7)3VB
T1F)63T
6TX)7LC
JXG)6HS
85G)4P9
94S)DYQ
YF3)MC5
WDZ)QZ3
NLN)3MG
NY9)HYY
SQR)HQB
FKZ)RRC
K52)T37
VY8)CTX
R4Q)QMF
R7S)FFV
BFF)WKQ
Z23)F1Q
WLB)7XJ
TYK)YRQ
4CM)YWT
M39)P6H
4XX)V6T
HTY)HMN
HMN)KJY
NCK)79H
5W3)DXH
VQK)7LM
GBS)YR2
7RY)LWS
1BM)2Y2
CM6)313
X8T)68C
Q6T)6B6
GSS)2G7
1K6)FKQ
V7T)PYC
6Y7)C1N
FZK)QVV
T16)3YY
TB4)5JL
7NX)WWX
H6P)YTY
Y5K)92P
WVH)15G
4BW)DB2
V47)PK9
K8M)9YL
M21)BYT
KCS)9Z4
JFN)P5S
RH7)BC5
RP1)PDM
XYW)YYR
KTY)MXD
X8J)FR9
X33)6C4
L97)9X3
GTF)NPK
6TG)1J8
XN3)M21
BZQ)44N
NRN)SAN
6X9)DBB
BPY)WMD
CK2)XQP
8Q1)S5P
63S)7HV
CYC)XY4
Q7P)M45
PW7)YS1";

        [Fact]
        public void Sample_map_is_parsed_correctly()
        {
            const string sampleMap = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
";

            var map = OrbitMap.Parse(sampleMap);

            Assert.Equal(3, map.OrbitsFrom("D"));
            Assert.Equal(7, map.OrbitsFrom("L"));
            Assert.Equal(0, map.OrbitsFrom("COM"));
            Assert.Equal(42, map.TotalOrbits());
        }

        [Fact]
        public void Direct_orbits_are_recorded()
        {
            var map = OrbitMap.Parse(@"COM)A");
            Assert.Equal(1, map.OrbitsFrom("A"));
        }

        [Fact]
        public void Indirect_orbits_are_recorded()
        {
            var map = OrbitMap.Parse(@"COM)A
A)B");
            Assert.Equal(2, map.OrbitsFrom("B"));
        }

        [Fact]
        public void Real_input_runs()
        {
            var map = OrbitMap.Parse(MapDescriptor);
            Assert.Equal(55, map.TotalOrbits());
        }
    }
}